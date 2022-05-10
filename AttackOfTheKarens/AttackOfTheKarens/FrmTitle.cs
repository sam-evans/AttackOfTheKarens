using KarenLogic;
using System;
using System.Media;
using System.Windows.Forms;

namespace AttackOfTheKarens {
  public partial class FrmTitle : Form {
    SoundPlayer? player;
    public FrmTitle() {
      InitializeComponent();
    }

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
        player?.Stop();       
    }

    private void FrmTitle_FormClosed(object sender, FormClosedEventArgs e) {
      Game.openForms.Remove(this);
      Game.CloseAll();
    }
  }
}
