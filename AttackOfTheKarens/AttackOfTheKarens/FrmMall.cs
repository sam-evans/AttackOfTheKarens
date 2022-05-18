using KarenLogic;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Media;
using System.Windows.Forms;

namespace AttackOfTheKarens {
    public partial class FrmMall : Form {

        // consts
        private const int PANEL_PADDING = 10;
        private const int FORM_PADDING = 60;
        private const int CELL_SIZE = 64;
        private readonly Random rand = new Random();
        //private readonly Color[] colors = new Color[5] { Color.Red, Color.Green, Color.Blue, Color.Orange, Color.Yellow };

        private readonly Color colors = Color.Gray;

        // other privates
        private SoundPlayer player;
        private SoundPlayer player1;
        private PictureBox picOwner;
        private int xOwner;
        private int yOwner;
        private char[][] map;
        private static List<Store> stores;

        //publics
        public static bool[] feedAssigned = { false, false, false, false, false };
        public static Label[] feedLabels = new Label[5];

        //animations
        private PictureBox testPic;
        private FrameAnimation testAni;
        private PictureBox? dollarSign;
        private MoveAnimation? dollarAni;
        private PictureBox? fireworks;
        private int fireworks_total_time = 3;
        private static bool fireworksOn = false;
        private static int fireworks_start_time;


        // ctor
        public FrmMall() {
            Game.openForms.Add(this);
            InitializeComponent();
        }

        // functions
        private void LoadMap() {
            string fileContents = File.ReadAllText("data/mall.txt");
            string[] lines = fileContents.Split(Environment.NewLine);
            map = new char[lines.Length][];
            for (int i = 0; i < lines.Length; i++) {
                map[i] = lines[i].ToCharArray();
            }
        }

        //create a picture box of size 64x64
        private PictureBox CreatePic(Image img, int top, int left) {
            return CreatePic(img, top, left, CELL_SIZE, CELL_SIZE);
        }

        //create a picture box of any size
        private PictureBox CreatePic(Image img, int top, int left, int w, int h) {
            return new PictureBox() {
                Image = img,
                Top = top,
                Left = left,
                Width = w,
                Height = h,
            };
        }

        private PictureBox CreateWall(Color color, Image img, int top, int left) {
            PictureBox picWall = CreatePic(img, top, left);
            picWall.Image.Tint(color);
            return picWall;
        }

        private void GenerateMall(Color color) {
            panMall.Controls.Clear();
            int top = 0;
            int left = 0;

            //create a new animation
            //this animation will update every 1 * 0.1 seconds.
            testAni = new FrameAnimation(10);

            //add the images for 1, 2 and 3 to the animation
            testAni.Add(Properties.Resources.one);
            testAni.Add(Properties.Resources.two);
            testAni.Add(Properties.Resources.three);

            //create a picture box. the image inside the picture box gets replaced
            //by images in the animations object
            testPic = CreatePic(testAni.Complete(), 0, 0);

            //add the picture box to the mall control.
            /* panMall.Controls.Add(testPic); */

            PictureBox pic = null;
            foreach (char[] array in map) {
                foreach (char c in array) {
                    switch (c) {
                        case 'K':
                            pic = CreatePic(Properties.Resources.karen0, top, left);
                            PictureBox healthBar = CreatePic(Properties.Resources.health8, top+CELL_SIZE, left, CELL_SIZE, 8);
                            Store s = new Store(new Karen(pic, healthBar) {
                            Row = top / CELL_SIZE,
                            Col = left / CELL_SIZE,
                            });
                            stores.Add(s);
                            panMall.Controls.Add(healthBar);
                            break;
                        case 'o':
                            picOwner = CreatePic(Properties.Resources.owner, top, left);
                            xOwner = left / CELL_SIZE;
                            yOwner = top / CELL_SIZE;
                            panMall.Controls.Add(picOwner);
                            break;
                        case 'w': pic = CreatePic(Properties.Resources.water, top, left); break;
                        case '-': pic = CreateWall(color, Properties.Resources.hline, top, left); break;
                        case '|': pic = CreateWall(color, Properties.Resources.vline, top, left); break;
                        case 'a': pic = CreateWall(color, Properties.Resources.a, top, left); break;
                        case 'b': pic = CreateWall(color, Properties.Resources.b, top, left); break;
                        case 'c': pic = CreateWall(color, Properties.Resources.c, top, left); break;
                        case 'd': pic = CreateWall(color, Properties.Resources.d, top, left); break;
                        case 'e': pic = CreateWall(color, Properties.Resources.e, top, left); break;
                        case 'f': pic = CreateWall(color, Properties.Resources.f, top, left); break;
                        case 'g': pic = CreateWall(color, Properties.Resources.g, top, left); break;
                        case 'h': pic = CreateWall(color, Properties.Resources.h, top, left); break;
                    }
                    left += CELL_SIZE;
                    if (pic != null) {
                        panMall.Controls.Add(pic);
                    }
                }
                left = 0;
                top += CELL_SIZE;
            }

            picOwner.BringToFront();
            panMall.Width = CELL_SIZE * map[0].Length + PANEL_PADDING + 165;
            panMall.Height = CELL_SIZE * map.Length + PANEL_PADDING;
            this.Width = panMall.Width + FORM_PADDING + 75;
            this.Height = panMall.Height + FORM_PADDING;
            this.Left = this.Left - 200;
            lblPrestige.Left = this.Width - 300;
            lblMoneySaved.Left = this.Width - 300;
            lblMoneySavedLabel.Left = this.Width - 300;
            lblPrestige.Top = this.Height - 100;
            lblMoneySavedLabel.Top = 25;
            lblMoneySaved.Top = lblMoneySavedLabel.Height + 30;
            feedLabels[0] = lblMoneyFeed1;
            feedLabels[1] = lblMoneyFeed2;
            feedLabels[2] = lblMoneyFeed3;
            feedLabels[3] = lblMoneyFeed4;
            feedLabels[4] = lblMoneyFeed5;
            for (int n=0; n<feedLabels.Length; n++) {
                feedLabels[n].Left = this.Width - 300;
                feedLabels[n].Top = lblMoneySavedLabel.Height + 65 + 30 * n;
            }
        }

        private void FrmMall_Load(object sender, EventArgs e) {
            stores = new List<Store>();
            LoadMap();
            GenerateMall(colors);
            tmrKarenSpawner.Interval = rand.Next(1000, 5000);
            tmrKarenSpawner.Enabled = true;
            player = new SoundPlayer();
            player.SoundLocation = "data/Spinning.wav";
            player.PlayLooping();
        }

        private bool IsInBounds(int newRow, int newCol) {
            return (newRow >= 0 && newRow < map.Length && newCol >= 0 && newCol < map[0].Length);
        }

        private bool IsWalkable(int newRow, int newCol) {
            char[] walkableTiles = new char[] { ' ', 'o', 'K', '0', '1', '2', '3', '4', '5', '6', '7', '8', '9', 'L' };
            return walkableTiles.Contains(map[newRow][newCol]);
        }

        public static void UpdateLabels() {
            FrmMall.feedLabels[0].Text = "";
            FrmMall.feedLabels[1].Text = "";
            FrmMall.feedLabels[2].Text = "";
            FrmMall.feedLabels[3].Text = "";
            FrmMall.feedLabels[4].Text = "";
            FrmMall.feedAssigned[0] = false;
            FrmMall.feedAssigned[1] = false;
            FrmMall.feedAssigned[2] = false;
            FrmMall.feedAssigned[3] = false;
            FrmMall.feedAssigned[4] = false;
        }

        private bool CanMove(Direction dir, out int newRow, out int newCol) {
            newRow = yOwner;
            newCol = xOwner;
            switch (dir) {
                case Direction.UP: newRow--; break;
                case Direction.DOWN: newRow++; break;
                case Direction.LEFT: newCol--; break;
                case Direction.RIGHT: newCol++; break;
            }
            return (IsInBounds(newRow, newCol) && IsWalkable(newRow, newCol));
        }

        private new void Move(Direction dir) {
            if (CanMove(dir, out int newRow, out int newCol)) {
                yOwner = newRow;
                xOwner = newCol;
                picOwner.Top = yOwner * CELL_SIZE;
                picOwner.Left = xOwner * CELL_SIZE;
                char mapTile = map[newRow][newCol];
                switch (mapTile) {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                    stores[int.Parse(mapTile.ToString())].OwnerWalksIn();
                    break;
                    case 'L':
                    foreach (Store store in stores) {
                        store.ResetOwner();
                    }
                    break;
                }
            }
        }

        /// <summary>
        /// Begin a dollar animation at position (X,Y).
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        private void BeginDollarAnimation(int y, int x) {

            
            //create dollar sign picture box if it isnt created already
            if (dollarSign == null) { dollarSign = CreatePic(Properties.Resources.dollarSign, 0, 0); }

            //create a new animation for the sign at the given starting position
            dollarAni = new MoveAnimation(y, x, -32, 0, 10);
           

            //set the dollar sign to the starting position
            dollarSign.Top = dollarAni.GetTop();
            dollarSign.Left = dollarAni.GetLeft();

            //add the dollar sign to controls
            panMall.Controls.Add(dollarSign);

            //set the sign visible and at the front
            dollarSign.Visible = true;
            dollarSign.BringToFront();
            
        }

        private void FrmMall_KeyUp(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Up: Move(Direction.UP); break;
                case Keys.Down: Move(Direction.DOWN); break;
                case Keys.Left: Move(Direction.LEFT); break;
                case Keys.Right: Move(Direction.RIGHT); break;
            }
        }

        private void tmrKarenSpawner_Tick(object sender, EventArgs e) {
            Store s = stores[rand.Next(stores.Count)];
            s.ActivateTheKaren();

            //set karen image based off of karen level
            int level = s.GetLevel();
            Image img;
            if (level == 0) { img = Properties.Resources.karen0; }
            else if (level == 1) { img = Properties.Resources.karen1; }
            else if (level == 2) { img = Properties.Resources.karen2; }
            else { img = Properties.Resources.karen3; }
            s.GetKarenPB().Image = img;
        }

        private void FrmMall_FormClosed(object sender, FormClosedEventArgs e) {
            Game.openForms.Remove(this);
            Game.CloseAll();
        }
        int j = 1;
        private void tmrUpdateKarens_Tick(object sender, EventArgs e) {
            if (stores != null && stores.Count > 0) {
                foreach (Store store in stores) {
                    store.Update();

                    //if a karen was just defeated, begin dollar sign animation and set karen back to not defeated
                    //also, add money earned to money feed
                    if (store.IsDefeated())
                    {
                        BeginDollarAnimation(store.GetTop(), store.GetLeft());
                        store.Reset();

                        //if not all 5 feed text fields have been assigned yet, then assign one by one
                        if (!feedAssigned[4])
                        {
                            for (int n = 0; n < feedAssigned.Length; n++)
                            {
                                if (!feedAssigned[n])
                                {
                                    feedAssigned[n] = true;
                                    feedLabels[n].Text = store.GetScore().ToString("+ $ #,##0.00");
                                    break;
                                }
                            }
                        }

                        //if all 5 fields have been assigned, "scroll" the feed
                        else
                        {
                            for (int n = 0; n < feedAssigned.Length - 1; n++) { feedLabels[n].Text = feedLabels[n + 1].Text; }
                            feedLabels[4].Text = store.GetScore().ToString("+ $ #,##0.00");
                        }
                    }

                    //if a karen hasnt been defeated yet, manage health bar
                    else {
                        int healthBars = store.getHealthBars();
                        PictureBox healthBarPB = store.GetHealthPB();
                        switch (healthBars) {
                            case 8:
                                healthBarPB.Image = Properties.Resources.health8;
                                break;
                            case 7:
                                healthBarPB.Image = Properties.Resources.health8;
                                break;
                            case 6:
                                healthBarPB.Image = Properties.Resources.health7;
                                break;
                            case 5:
                                healthBarPB.Image = Properties.Resources.health6;
                                break;
                            case 4:
                                healthBarPB.Image = Properties.Resources.health5;
                                break;
                            case 3:
                                healthBarPB.Image = Properties.Resources.health4;
                                break;
                            case 2:
                                healthBarPB.Image = Properties.Resources.health3;
                                break;
                            case 1:
                                healthBarPB.Image = Properties.Resources.health2;
                                break;
                            case 0:
                                healthBarPB.Image = Properties.Resources.health1;
                                break;
                        }
                        healthBarPB.BringToFront();
                    }
                }
            }
        }

        private void tmrMoveOwner_Tick(object sender, EventArgs e) {
            Direction dir = (Direction)rand.Next(4);
            Move(dir);
        }

        private void tmrUpdateGame_Tick(object sender, EventArgs e) {
            lblMoneySaved.Text = Game.Score.ToString("$ #,##0.00");
            lblPrestige.Text = "Prestige: " + Game.PrestigeLevel;
        }

        private void panMall_Paint(object sender, PaintEventArgs e) { }

        public static void TurnOnFireworks() {
            fireworksOn = true;
            fireworks_start_time = DateTime.Now.Second;
        }

        /// <summary>
        /// Update animations every 100ms.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        private void tmrAnimationsUpdate_Tick(object sender, EventArgs e)
        {
            //update the animation so it knows when to go to the next frame
            testAni.Update();

            //if the next frame is ready, replace the image in the picture box
            if (testAni.ImageReady()) { testPic.Image = testAni.GetImage(); }

            //only perform dollar animation if it is currently active
            if (dollarAni != null && dollarSign != null && dollarSign.Visible)
            {

                //update animation
                dollarAni.Update();

                //grab new image positions from animation
                dollarSign.Top = dollarAni.GetTop();
                dollarSign.Left = dollarAni.GetLeft();

                //if animation is done then set the dollar sign back to not visible
                if (dollarAni.isDone()) { dollarSign.Visible = false; }
            }

            //fireworks animation
            if (fireworksOn) {
                if (fireworks == null) {
                    fireworks = CreatePic(Properties.Resources.fireworks, 300, this.Width-300, 165, 165);
                    panMall.Controls.Add(fireworks);
                }
                if (DateTime.Now.Second - fireworks_start_time > fireworks_total_time) {
                    panMall.Controls.Remove(fireworks);
                    fireworks = null;
                    fireworksOn = false;
                }
            }
        }

        private void PrestigeMenuButton_Click(object sender, EventArgs e)
        {
            PrestigeMenu popup = new PrestigeMenu();
            DialogResult dialogresult = popup.ShowDialog();
            if (dialogresult == DialogResult.Cancel)
            {
                Console.WriteLine("You clicked either Cancel or X button in the top right corner");
            }
            popup.Dispose();
        }
        int i = 0;
       private void MuteButton_Click(object sender, EventArgs e)
        {
            if (i == 0)
            {
                player?.Stop();
                i++;
            }
            else
            {
                player?.Play();
                i--;
            }
        }

        private void ShopButton_Click(object sender, EventArgs e)
        {
            ItemsShop popup = new ItemsShop();
            DialogResult dialogresult = popup.ShowDialog();
            if (dialogresult == DialogResult.Cancel)
            {
                Console.WriteLine("You clicked either Cancel or X button in the top right corner");
            }
            popup.Dispose();
        }

      

        public static void WipeButton()
        {
           
            
            for (int p = 0; p < stores.Count(); p++)
            {
                stores[p].Wipe();
                
            }
            
        }
        public static void Charisma(int i)
        {
            for (int p = 0; p < stores.Count(); p++)
            {
                stores[p].setUpdate(i);

            }
            
        }
        
    }
}
