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
    private readonly Color[] colors = new Color[5] { Color.Red, Color.Green, Color.Blue, Color.Orange, Color.Yellow };

    // other privates
    private SoundPlayer player;
    private PictureBox picOwner;
    private int xOwner;
    private int yOwner;
    private char[][] map;
    private List<Store> stores;

    //test animation object
    private PictureBox testPic;
    private Animation testAni;

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

    private PictureBox CreatePic(Image img, int top, int left) {
      return new PictureBox() {
        Image = img,
        Top = top,
        Left = left,
        Width = CELL_SIZE,
        Height = CELL_SIZE,
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
      testAni = new Animation(10);

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
              pic = CreatePic(Properties.Resources.karen, top, left);
              Store s = new Store(new Karen(pic) {
                Row = top / CELL_SIZE,
                Col = left / CELL_SIZE,
              });
              stores.Add(s);
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
      panMall.Width = CELL_SIZE * map[0].Length + PANEL_PADDING;
      panMall.Height = CELL_SIZE * map.Length + PANEL_PADDING;
      this.Width = panMall.Width + FORM_PADDING + 75;
      this.Height = panMall.Height + FORM_PADDING;
      lblMoneySaved.Left = this.Width - lblMoneySaved.Width - 10;
      lblMoneySavedLabel.Left = this.Width - lblMoneySavedLabel.Width - 10;
      lblMoneySavedLabel.Top = 0;
      lblMoneySaved.Top = lblMoneySavedLabel.Height + 5;
    }

    private void FrmMall_Load(object sender, EventArgs e) {
      stores = new List<Store>();
      LoadMap();
      GenerateMall(colors[rand.Next(colors.Length)]);
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
    }

    private void FrmMall_FormClosed(object sender, FormClosedEventArgs e) {
      Game.openForms.Remove(this);
      Game.CloseAll();
    }

    private void tmrUpdateKarens_Tick(object sender, EventArgs e) {
      if (stores != null && stores.Count > 0) {
        foreach (Store store in stores) {
          store.Update();
        }
      }
    }

    private void tmrMoveOwner_Tick(object sender, EventArgs e) {
      Direction dir = (Direction)rand.Next(4);
      Move(dir);
    }

    private void tmrUpdateGame_Tick(object sender, EventArgs e) {
      lblMoneySaved.Text = Game.Score.ToString("$ #,##0.00");
    }

    private void panMall_Paint(object sender, PaintEventArgs e)
    {

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
        /* if (testAni.ImageReady()) { testPic.Image = testAni.GetImage(); } */
    }
  }
}
