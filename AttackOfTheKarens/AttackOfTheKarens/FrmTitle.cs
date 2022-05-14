using KarenLogic;
using System;
using System.Media;
using System.Windows.Forms;

namespace AttackOfTheKarens {
  public partial class FrmTitle : Form {
    SoundPlayer? player;
        int i = 0;
    public FrmTitle() {
      InitializeComponent();
    }
    //A COMMENT THAT SHOULD STAY HERE
    private void FrmTitle_Load(object sender, EventArgs e) {
      Game.openForms.Add(this);
      player = new SoundPlayer();
      player.SoundLocation = "data/trailer.wav";
      player.PlayLooping();
    }

    private void btnStart_Click(object sender, EventArgs e) {
      player?.Stop();
      FrmMall frmMall = new FrmMall();
      frmMall.Show();
      this.Hide();
    }
    private void btnMute_Click(object sender, EventArgs e) {
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

    private void FrmTitle_FormClosed(object sender, FormClosedEventArgs e) {
      Game.openForms.Remove(this);
      Game.CloseAll();
    }
  }
}
