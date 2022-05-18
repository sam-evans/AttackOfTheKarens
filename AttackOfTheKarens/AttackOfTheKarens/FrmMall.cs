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
        private int xOwner;
        private int yOwner;
        private char[][] map;
        private static List<Store> stores;

        // used for movement
        private List<int> Kspwns;
        private List<Direction> toKaren = new List<Direction>();
        private Queue<Tuple<int, int, int, int>> nextspwn = new Queue<Tuple<int, int, int, int>>();
        private Stack<int> reversePath = new Stack<int>();
        private Tuple<int, int, int, int> curHunted = new Tuple<int, int, int, int>(999, 999, 999, 999);
        private bool didnotmove = false;
        private bool defeated = false;
        private int prevMove;
        private static bool upgraded = false;

        //publics
        public static bool[] feedAssigned = { false, false, false, false, false };
        public static Label[] feedLabels = new Label[5];

        //animations
        private LinkedList<PictureBox> dollarSign = new LinkedList<PictureBox>();
        private LinkedList<MoveAnimation> dollarAni = new LinkedList<MoveAnimation>();
        private PictureBox? fireworks;
        private int fireworks_total_time = 3;
        private static bool fireworksOn = false;
        private static int fireworks_start_time;
        private PictureBox owner;
        private FrameAnimation ownerAni;
        private FrameAnimation karen0;
        private FrameAnimation karen1;
        private FrameAnimation karen2;
        private FrameAnimation karen3;


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

            //karen animations
            karen0 = new FrameAnimation(1);
            karen0.Add(Properties.Resources.karen00);
            karen0.Add(Properties.Resources.karen01);
            karen1 = new FrameAnimation(1);
            karen1.Add(Properties.Resources.karen10);
            karen1.Add(Properties.Resources.karen11);
            karen2 = new FrameAnimation(1);
            karen2.Add(Properties.Resources.karen20);
            karen2.Add(Properties.Resources.karen21);
            karen3 = new FrameAnimation(1);
            karen3.Add(Properties.Resources.karen30);
            karen3.Add(Properties.Resources.karen31);

            //Save the spawns for use in movement calculations
            Kspwns = new List<int>();

            PictureBox pic = null;
            foreach (char[] array in map) {
                foreach (char c in array) {
                    switch (c) {
                        case 'K':
                            pic = CreatePic(Properties.Resources.karen00, top, left);
                            PictureBox healthBar = CreatePic(Properties.Resources.health8, top+CELL_SIZE, left, CELL_SIZE, 8);
                            Store s = new Store(new Karen(pic, healthBar) {
                            Row = top / CELL_SIZE,
                            Col = left / CELL_SIZE,
                            });
                            stores.Add(s);
                            panMall.Controls.Add(healthBar);

                            //save the position of the karen for later use
                            int Row = top / CELL_SIZE;
                            int Col = left / CELL_SIZE;

                            Kspwns.Add(Row);
                            Kspwns.Add(Col);
                            break;
                        case 'o':
                            owner = CreatePic(Properties.Resources.owner0, top, left);
                            ownerAni = new FrameAnimation(1);
                            ownerAni.Add(Properties.Resources.owner0);
                            ownerAni.Add(Properties.Resources.owner1);
                            xOwner = left / CELL_SIZE;
                            yOwner = top / CELL_SIZE;
                            panMall.Controls.Add(owner);
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

            owner.BringToFront();
            panMall.Width = CELL_SIZE * map[0].Length + PANEL_PADDING + 165;
            panMall.Height = CELL_SIZE * map.Length + PANEL_PADDING;
            this.Width = panMall.Width + FORM_PADDING + 75;
            this.Height = panMall.Height + FORM_PADDING;
            this.Left = this.Left - 200;
            lblNextPrestigeCostLabel.Left = this.Width - 300;
            lblNextPrestigeCost.Left = this.Width - 300;
            lblPrestige.Left = this.Width - 300;
            lblMoneySaved.Left = this.Width - 300;
            lblMoneySavedLabel.Left = this.Width - 300;
            lblNextPrestigeCostLabel.Top = this.Height - 170;
            lblNextPrestigeCost.Top = this.Height - 150;
            lblPrestige.Top = this.Height - 100;
            lblMoneySavedLabel.Top = 25;
            lblMoneySaved.Top = lblMoneySavedLabel.Height + 20;
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
                case Direction.NORTH: newRow--; break;
                case Direction.SOUTH: newRow++; break;
                case Direction.WEST: newCol--; break;
                case Direction.EAST: newCol++; break;
                case Direction.NORTHWEST: newRow--; newCol--; break;
                case Direction.NORTHEAST: newRow--; newCol++; break;
                case Direction.SOUTHEAST: newRow++; newCol++; break;
                case Direction.SOUTHWEST: newRow++; newCol--; break;
                case Direction.NOMOVE: break;
            }
            return (IsInBounds(newRow, newCol) && IsWalkable(newRow, newCol));
        }

        private new void Move(Direction dir) {
            if (CanMove(dir, out int newRow, out int newCol)) {
                yOwner = newRow;
                xOwner = newCol;
                owner.Top = yOwner * CELL_SIZE;
                owner.Left = xOwner * CELL_SIZE;
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
                didnotmove = false;
            }
            else
            {
                didnotmove = true;
            }
        }

        /// <summary>
        /// Begin a dollar animation at position (X,Y).
        /// </summary>
        /// <param name="y"></param>
        /// <param name="x"></param>
        private void BeginDollarAnimation(int y, int x) {

            //create dollar sign picture box if it isnt created already
            PictureBox curPic = CreatePic(Properties.Resources.dollarSign, 0, 0);
            dollarSign.AddLast(curPic);

            //create a new animation for the sign at the given starting position
            MoveAnimation curAni = new MoveAnimation(y, x, -32, 0, 10);
            dollarAni.AddLast(curAni);


            //set the dollar sign to the starting position
            curPic.Top = curAni.GetTop();
            curPic.Left = curAni.GetLeft();

            //add the dollar sign to controls
            panMall.Controls.Add(curPic);

            //set the sign visible and at the front
            curPic.Visible = true;
            curPic.BringToFront();
            
        }

        private void FrmMall_KeyUp(object sender, KeyEventArgs e) {
            switch (e.KeyCode) {
                case Keys.Up: Move(Direction.NORTH); break;
                case Keys.Down: Move(Direction.SOUTH); break;
                case Keys.Left: Move(Direction.WEST); break;
                case Keys.Right: Move(Direction.EAST); break;
            }
        }

        private void tmrKarenSpawner_Tick(object sender, EventArgs e) {
            Store s = stores[rand.Next(stores.Count)];
            s.ActivateTheKaren();

            //set karen image based off of karen level
            int level = s.GetLevel();
            Image img;
            if (level == 0) { img = Properties.Resources.karen00; }
            else if (level == 1) { img = Properties.Resources.karen10; }
            else if (level == 2) { img = Properties.Resources.karen20; }
            else { img = Properties.Resources.karen30; }
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

        private Direction OC_Move(Direction desiredMove)
        {
            System.Diagnostics.Debug.WriteLine("COLLISIONS");
            //check for corners
            // Top Right Corner
            if (!CanMove(Direction.NORTH, out int newRow, out int newCol) && !CanMove(Direction.EAST, out newRow, out newCol) && !CanMove(Direction.NORTHEAST, out newRow, out newCol))
            {
                if (toKaren.Contains(Direction.SOUTH))
                {
                    if (!CanMove(Direction.EAST, out newRow, out newCol))
                    {
                        prevMove = 4;
                        Move(Direction.SOUTH);
                        Move(Direction.SOUTH);
                        return Direction.EAST;
                    }
                }
                else if (CanMove(Direction.SOUTH, out newRow, out newCol))
                {
                    prevMove = 2;
                    Move(Direction.SOUTH);
                    Move(Direction.SOUTH);
                    return Direction.SOUTH;
                }

            }
            // Bottom Right Corner
            else if (!CanMove(Direction.SOUTH, out newRow, out newCol) && !CanMove(Direction.EAST, out newRow, out newCol) && !CanMove(Direction.SOUTHEAST, out newRow, out newCol))
            {
                if (!CanMove(Direction.SOUTH, out newRow, out newCol))
                {
                    prevMove = 2;
                    Move(Direction.WEST);
                    Move(Direction.SOUTH);
                    return Direction.SOUTH;
                }
            }
            // Bottom Left Corner
            else if (!CanMove(Direction.SOUTH, out newRow, out newCol) && !CanMove(Direction.WEST, out newRow, out newCol) && !CanMove(Direction.SOUTHWEST, out newRow, out newCol))
            {
                if (toKaren.Contains(Direction.SOUTHWEST))
                {
                    prevMove = 2;
                    Move(Direction.EAST);
                    Move(Direction.NORTH);
                    return Direction.EAST;
                }
                if (CanMove(Direction.EAST, out newRow, out newCol))
                {
                    prevMove = 2;
                    Move(Direction.EAST);
                    Move(Direction.SOUTH);
                    return Direction.EAST;
                }
            }
            // Top Left
            else if (!CanMove(Direction.NORTH, out newRow, out newCol) && !CanMove(Direction.WEST, out newRow, out newCol) && !CanMove(Direction.NORTHWEST, out newRow, out newCol))
            {
                if (toKaren.Contains(Direction.SOUTHWEST) && toKaren.Contains(Direction.WEST))
                {
                    prevMove = 4;
                    Move(Direction.EAST);
                    Move(Direction.EAST);
                    Move(Direction.SOUTH);
                    Move(Direction.SOUTH);
                    Move(Direction.SOUTH);
                    Move(Direction.WEST);
                    Move(Direction.WEST);
                    Move(Direction.WEST);
                    return Direction.SOUTH;
                }
                else if (toKaren.Contains(Direction.NORTH) || toKaren.Contains(Direction.NORTHWEST))
                {
                    prevMove = 6;
                    Move(Direction.EAST);
                    Move(Direction.NORTH);
                    return Direction.NORTH;
                }
            }
            //shouldn't be in a corner anymore
            switch (desiredMove)
            {
                // north east
                case Direction.NORTHEAST:
                    //check which direction is blocked
                    if (toKaren.Contains(Direction.NORTH))
                    {
                        prevMove = 2;
                        Move(Direction.SOUTH);
                        return Direction.SOUTH;
                    }
                    if (CanMove(Direction.EAST, out newRow, out newCol))
                    {
                        prevMove = 4;
                        return Direction.EAST;
                    }
                    else if (CanMove(Direction.NORTH, out newRow, out newCol))
                    {
                        prevMove = 6;
                        return Direction.NORTH;
                    }
                    break;
                case Direction.NORTH:
                    if (toKaren.Contains(Direction.NORTHEAST))
                    {
                        if (CanMove(Direction.EAST, out newRow, out newCol))
                        {
                            prevMove = 4;
                            Move(Direction.EAST);
                            return Direction.EAST;
                        }
                    }
                    else if (CanMove(Direction.EAST, out newRow, out newCol))
                    {
                        prevMove = 4;
                        Move(Direction.EAST);
                        return Direction.EAST;
                    }
                    break;
                case Direction.NORTHWEST:
                    if (CanMove(Direction.NORTH, out newRow, out newCol))
                    {
                        prevMove = 6;
                        return Direction.NORTH;
                    }
                    else if (CanMove(Direction.WEST, out newRow, out newCol))
                    {
                        prevMove = 4;
                        return Direction.WEST;
                    }
                    break;
                case Direction.EAST:
                    if (toKaren.Contains(Direction.NORTH))
                    {
                        prevMove = 2;
                        return Direction.SOUTH;
                    }
                    else if (CanMove(Direction.NORTH, out newRow, out newCol))
                    {
                        prevMove = 6;
                        return Direction.NORTH;
                    }
                    break;
                case Direction.WEST:
                    if (CanMove(Direction.SOUTHWEST, out newRow, out newCol))
                    {
                        prevMove = 1;
                        return Direction.SOUTHWEST;
                    }
                    break;
                case Direction.SOUTHEAST:
                    if (CanMove(Direction.EAST, out newRow, out newCol))
                    {

                        prevMove = 4;
                        return Direction.EAST;
                    }
                    else if (CanMove(Direction.SOUTH, out newRow, out newCol))
                    {
                        prevMove = 2;
                        Move(Direction.SOUTH);
                        return Direction.SOUTH;
                    }
                    break;
                case Direction.SOUTHWEST:
                    if (CanMove(Direction.EAST, out newRow, out newCol))
                    {
                        prevMove = 4;
                        return Direction.EAST;
                    }
                    break;
                case Direction.SOUTH:
                    if (toKaren.Contains(Direction.WEST))
                    {
                        prevMove = 4;
                        return Direction.EAST;
                    }
                    break;
            }
            return Direction.NOMOVE;
        }

        public static void upgradeMove() { upgraded = true; }

        private void tmrMoveOwner_Tick(object sender, EventArgs e) {
            //get Managers current position in the map
            int curposR = owner.Top / CELL_SIZE;
            int curposC = owner.Left / CELL_SIZE;
            var Kdist = new List<Tuple<int, int, int, int>> { };
            double dist;
            double temp;
            int j = 0;
            Tuple<int, int, int, int> nearestKarenTup = new(999, 999, 999, 999);
            // use a queue to determine which karen we should go to
            // Tuple: (dist, Row, Col, Store)
            //NOTE: dist is calculated once, at the original spawn of the owner.
            //find the positions of the karens
            if (nextspwn.Count() == null)
            {
                nextspwn = new Queue<Tuple<int, int, int, int>>();
            }

            if (nextspwn.Count() == 0)
            {
                for (int i = 0; i < Kspwns.LongCount(); i = i + 2)
                {
                    //find the nearest karen
                    // check each karens position and determine which karen is closest
                    var curKaren = Tuple.Create(Kspwns[i], Kspwns[i + 1]);
                    temp = Math.Pow((curposC - curKaren.Item2), 2) + Math.Pow((curposR - curKaren.Item1), 2);
                    dist = Math.Sqrt(temp);
                    // Tuple: <Dist to karen, Row, Col, Store#>
                    Kdist.Add(new Tuple<int, int, int, int>((int)dist, curKaren.Item1, curKaren.Item2, j));

                    //get the nearest karen and save the tuple for later use
                    j++;
                }
                //create a queue where the first item is the closest karen and the last item is the farthest karen
                int leng = Kdist.Count();
                for (int n = 0; n < leng; n++)
                {
                    nearestKarenTup = Kdist.Min();
                    Kdist.Remove(nearestKarenTup);
                    nextspwn.Enqueue(nearestKarenTup);

                }

            }


            if (!upgraded)
            {
                Direction dir = (Direction)rand.Next(8);
                Move(dir);
            }
            else if (upgraded)
            {
                System.Diagnostics.Debug.WriteLine("in the new movement");

                //get the nearest karen
                if (curHunted.Item1 == 999)
                {
                    System.Diagnostics.Debug.WriteLine("if1 got hunted");
                    curHunted = nextspwn.Dequeue();
                }
                else if (stores[curHunted.Item4].IsThere() == false)
                {
                    System.Diagnostics.Debug.WriteLine("if2 got hunted");
                    curHunted = nextspwn.Dequeue();
                }

                //free movement
                // check to see if the current karen is visible
                if (stores[curHunted.Item4].IsThere() && didnotmove == false)
                {
                    System.Diagnostics.Debug.WriteLine("main if: free movement");
                    //now that we found a karen, go to him/her
                    //check west
                    if (curHunted.Item2 == curposR && curHunted.Item3 < curposC)
                    {
                        System.Diagnostics.Debug.WriteLine("hiting if 1");
                        Direction dir = 0;
                        prevMove = 0;
                        toKaren.Add(dir);
                        Move(dir);
                    }
                    //check south west
                    else if (curHunted.Item2 > curposR && curHunted.Item3 < curposC)
                    {
                        System.Diagnostics.Debug.WriteLine("hiting if 1");
                        Direction dir = (Direction)1;
                        prevMove = 1;
                        toKaren.Add(dir);
                        Move(dir);
                    }
                    //check south
                    else if (curHunted.Item2 > curposR && curHunted.Item3 == curposC)
                    {
                        System.Diagnostics.Debug.WriteLine("hiting if 2");
                        Direction dir = (Direction)2;
                        prevMove = 2;
                        toKaren.Add(dir);
                        Move(dir);
                    }
                    //check south east
                    else if (curHunted.Item2 > curposR && curHunted.Item3 > curposC)
                    {
                        System.Diagnostics.Debug.WriteLine("hiting if 3");
                        Direction dir = (Direction)3;
                        prevMove = 3;
                        toKaren.Add(dir);
                        Move(dir);
                    }
                    //check east
                    else if (curHunted.Item2 == curposR && curHunted.Item3 > curposC)
                    {
                        System.Diagnostics.Debug.WriteLine("hiting if 4");
                        Direction dir = (Direction)4;
                        prevMove = 4;
                        toKaren.Add(dir);
                        Move(dir);
                    }
                    //check north east
                    else if (curHunted.Item2 < curposR && curHunted.Item3 > curposC)
                    {
                        System.Diagnostics.Debug.WriteLine("hiting if 5");
                        Direction dir = (Direction)5;
                        prevMove = 5;
                        toKaren.Add(dir);
                        Move(dir);
                    }
                    //check north
                    else if (curHunted.Item2 < curposR && curHunted.Item3 == curposC)
                    {
                        System.Diagnostics.Debug.WriteLine("hiting if 6");
                        Direction dir = (Direction)6;
                        prevMove = 6;
                        toKaren.Add(dir);
                        Move(dir);
                    }
                    //check norsth west
                    else if (curHunted.Item2 < curposR && curHunted.Item3 < curposC)
                    {
                        System.Diagnostics.Debug.WriteLine("hiting if 7");
                        Direction dir = (Direction)7;
                        prevMove = 7;
                        toKaren.Add(dir);
                        Move(dir);
                    }
                    //if on the karen
                    else if (curHunted.Item2 == curposR && curHunted.Item3 == curposC)
                    {
                        System.Diagnostics.Debug.WriteLine("hiting if 8");
                        Direction dir = (Direction)8;
                        Move(dir);
                        toKaren.Clear();
                        if (stores[curHunted.Item4].getHealthBars() == 0)
                        {
                            defeated = true;
                        }
                    }
                    else
                    {
                        System.Diagnostics.Debug.WriteLine("failed free movement");
                    }

                }
                //object collision
                else if (stores[curHunted.Item4].IsThere() && didnotmove == true)
                {
                    System.Diagnostics.Debug.WriteLine("new movement OC");
                    Direction dir;
                    switch (prevMove)
                    {
                        //west
                        case 0:
                            dir = OC_Move((Direction)prevMove);
                            Move(dir);
                            break;
                        //south west
                        case 1:
                            dir = OC_Move((Direction)prevMove);
                            Move(dir);
                            break;
                        //south
                        case 2:
                            dir = OC_Move((Direction)prevMove);
                            Move(dir);
                            break;
                        //south east
                        case 3:
                            dir = OC_Move((Direction)prevMove);
                            Move(dir);
                            break;
                        //east
                        case 4:
                            dir = OC_Move((Direction)prevMove);
                            Move(dir);
                            break;
                        //north east
                        case 5:
                            dir = OC_Move((Direction)prevMove);
                            Move(dir);
                            break;
                        //north
                        case 6:
                            dir = OC_Move((Direction)prevMove);
                            Move(dir);
                            break;
                        //northwest
                        case 7:
                            dir = OC_Move((Direction)prevMove);
                            Move(dir);
                            break;
                        default:
                            break;
                    }
                }
                else
                {
                    System.Diagnostics.Debug.WriteLine("hit else after attempting free Move and OC");
                    Direction dir = (Direction)8; Move(dir);
                }

                //put the karen back after defeating her
                if (curHunted.Item1 != 999)
                {
                    nextspwn.Enqueue(curHunted);
                }
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("shits fucked");
            }
        }

        private void tmrUpdateGame_Tick(object sender, EventArgs e) {
            lblMoneySaved.Text = Game.Score.ToString("$ #,##0.00");
            lblPrestige.Text = "Prestige: " + Game.PrestigeLevel;
            lblNextPrestigeCost.Text = Game.PrestigeMenuCondition.ToString("$ #,##0.00");
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
            ownerAni.Update();
            karen0.Update();
            karen1.Update();
            karen2.Update();
            karen3.Update();

            //if the next frame is ready, replace the image in the picture box
            if (ownerAni.ImageReady()) { owner.Image = ownerAni.GetImage(); }

            //karen animations are special; multiple entities tied to one animation. requires different functions
            foreach (Store store in stores) {
                if (store.IsPresent()) {
                    switch (store.GetLevel()) {
                        case 0:
                            store.GetKarenPB().Image = karen0.GetImageMulti();
                            break;
                        case 1:
                            store.GetKarenPB().Image = karen1.GetImageMulti();
                            break;
                        case 2:
                            store.GetKarenPB().Image = karen2.GetImageMulti();
                            break;
                        case 3:
                            store.GetKarenPB().Image = karen3.GetImageMulti();
                            break;
                    }
                }
            }

            //manually set imageready to false in karen animations after frames have already been retrieved
            if (karen0.ImageReady()) { karen0.ImageGotten(); }
            if (karen1.ImageReady()) { karen1.ImageGotten(); }
            if (karen2.ImageReady()) { karen2.ImageGotten(); }
            if (karen3.ImageReady()) { karen3.ImageGotten(); }

            //only perform dollar animation if it is currently active
            if (dollarAni.Count > 0 && dollarSign.Count > 0) {

                //keep track of which pictureboxes/animations should be removed AFTER they have been processed
                LinkedList<PictureBox> toBeRemovedPic = new LinkedList<PictureBox>();
                LinkedList<MoveAnimation> toBeRemovedAni = new LinkedList<MoveAnimation>();

                //check each picturebox in the list of pictureboxes for dollar signs
                int element = 0;
                foreach (PictureBox curPic in dollarSign) {

                    //if the picture is currently visible, perform animation and check if animation is done
                    if (curPic.Visible) {
                        MoveAnimation curAni = dollarAni.ElementAt(element);
                        curAni.Update();

                        curPic.Top = curAni.GetTop();
                        curPic.Left = curAni.GetLeft();

                        if (curAni.isDone()) {
                            curPic.Visible = false;
                            toBeRemovedPic.AddLast(curPic);
                            toBeRemovedAni.AddLast(curAni);
                        }
                    }
                    element++;
                }

                //remove all tagged pictureboxes/animations
                foreach (PictureBox curPic in toBeRemovedPic) { dollarSign.Remove(curPic); }
                foreach (MoveAnimation curAni in toBeRemovedAni) { dollarAni.Remove(curAni); }
            }

            //fireworks animation
            if (fireworksOn) {

                //start animation from beginning of gif if fireworks have not been started yet
                if (fireworks == null) {
                    fireworks = CreatePic(Properties.Resources.fireworks, 300, this.Width-300, 165, 165);
                    panMall.Controls.Add(fireworks);
                }

                //if animation time is over, remove animation completely and turn off fireworks
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

        //instantly defeat all karens
        public static void WipeButton() {
            for (int p = 0; p < stores.Count(); p++) { stores[p].Defeat(); }
        }

        
        public static void Charisma(int i) {
            for (int p = 0; p < stores.Count(); p++) {
                stores[p].setUpdate(i);
            }
        }
        
    }
}
