namespace AttackOfTheKarens {
  partial class FrmMall {
    /// <summary>
    ///  Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    ///  Clean up any resources being used.
    /// </summary>
    /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
    protected override void Dispose(bool disposing) {
      if (disposing && (components != null)) {
        components.Dispose();
      }
      base.Dispose(disposing);
    }

    #region Windows Form Designer generated code

    /// <summary>
    ///  Required method for Designer support - do not modify
    ///  the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {
            this.components = new System.ComponentModel.Container();
            this.panMall = new DBPanel();
            this.tmrAnimationsUpdate = new System.Windows.Forms.Timer(this.components);
            this.tmrKarenSpawner = new System.Windows.Forms.Timer(this.components);
            this.tmrUpdateKarens = new System.Windows.Forms.Timer(this.components);
            this.tmrMoveOwner = new System.Windows.Forms.Timer(this.components);
            this.lblMoneySaved = new System.Windows.Forms.Label();
            this.lblMoneySavedLabel = new System.Windows.Forms.Label();
            this.tmrUpdateGame = new System.Windows.Forms.Timer(this.components);
            this.PrestigeMenuButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // panMall
            //
            this.panMall.BackColor = System.Drawing.Color.Transparent;
            this.panMall.BackgroundImage = global::AttackOfTheKarens.Properties.Resources.mall_bg;
            this.panMall.Location = new System.Drawing.Point(12, 12);
            this.panMall.Name = "panMall";
            this.panMall.Size = new System.Drawing.Size(561, 539);
            this.panMall.TabIndex = 0;
            this.panMall.Paint += new System.Windows.Forms.PaintEventHandler(this.panMall_Paint);
            // 
            // tmrAnimationsUpdate
            // 
            this.tmrAnimationsUpdate.Enabled = true;
            this.tmrAnimationsUpdate.Tick += new System.EventHandler(this.tmrAnimationsUpdate_Tick);
            // 
            // tmrKarenSpawner
            // 
            this.tmrKarenSpawner.Tick += new System.EventHandler(this.tmrKarenSpawner_Tick);
            // 
            // tmrUpdateKarens
            // 
            this.tmrUpdateKarens.Enabled = true;
            this.tmrUpdateKarens.Interval = 40;
            this.tmrUpdateKarens.Tick += new System.EventHandler(this.tmrUpdateKarens_Tick);
            // 
            // tmrMoveOwner
            // 
            this.tmrMoveOwner.Enabled = true;
            this.tmrMoveOwner.Interval = 120;
            this.tmrMoveOwner.Tick += new System.EventHandler(this.tmrMoveOwner_Tick);
            // 
            // lblMoneySaved
            // 
            this.lblMoneySaved.AutoSize = true;
            this.lblMoneySaved.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMoneySaved.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblMoneySaved.Location = new System.Drawing.Point(1075, -1);
            this.lblMoneySaved.Name = "lblMoneySaved";
            this.lblMoneySaved.Size = new System.Drawing.Size(98, 32);
            this.lblMoneySaved.TabIndex = 1;
            this.lblMoneySaved.Text = "$ 00.00";
            this.lblMoneySaved.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMoneySavedLabel
            // 
            this.lblMoneySavedLabel.AutoSize = true;
            this.lblMoneySavedLabel.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMoneySavedLabel.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.lblMoneySavedLabel.Location = new System.Drawing.Point(917, 6);
            this.lblMoneySavedLabel.Name = "lblMoneySavedLabel";
            this.lblMoneySavedLabel.Size = new System.Drawing.Size(137, 25);
            this.lblMoneySavedLabel.TabIndex = 2;
            this.lblMoneySavedLabel.Text = "Money Saved:";
            this.lblMoneySavedLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // tmrUpdateGame
            // 
            this.tmrUpdateGame.Enabled = true;
            this.tmrUpdateGame.Tick += new System.EventHandler(this.tmrUpdateGame_Tick);
            // 
            // PrestigeMenuButton
            // 
            this.PrestigeMenuButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.PrestigeMenuButton.Location = new System.Drawing.Point(1084, 425);
            this.PrestigeMenuButton.Name = "PrestigeMenuButton";
            this.PrestigeMenuButton.Size = new System.Drawing.Size(75, 23);
            this.PrestigeMenuButton.TabIndex = 3;
            this.PrestigeMenuButton.Text = "Prestige";
            this.PrestigeMenuButton.UseVisualStyleBackColor = true;
            this.PrestigeMenuButton.Click += new System.EventHandler(this.PrestigeMenuButton_Click);
            // 
            // FrmMall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1171, 698);
            this.Controls.Add(this.PrestigeMenuButton);
            this.Controls.Add(this.lblMoneySavedLabel);
            this.Controls.Add(this.lblMoneySaved);
            this.Controls.Add(this.panMall);
            this.Name = "FrmMall";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Attack of the Karens!!";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMall_FormClosed);
            this.Load += new System.EventHandler(this.FrmMall_Load);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.FrmMall_KeyUp);
            this.ResumeLayout(false);
            this.PerformLayout();

    }

    #endregion

    private DBPanel panMall;
    private System.Windows.Forms.Timer tmrKarenSpawner;
    private System.Windows.Forms.Timer tmrUpdateKarens;
    private System.Windows.Forms.Timer tmrMoveOwner;
    private System.Windows.Forms.Label lblMoneySaved;
    private System.Windows.Forms.Label lblMoneySavedLabel;
    private System.Windows.Forms.Timer tmrUpdateGame;

    /// <summary>
    /// Tick timer for animations. Executes every 100ms.
    /// </summary>
    private System.Windows.Forms.Timer tmrAnimationsUpdate;
        private System.Windows.Forms.Button PrestigeMenuButton;
    }

    /// <summary>
    /// A double buffered panel that flickers much less than an normal panel.
    /// </summary>
    public class DBPanel : System.Windows.Forms.Panel {
        public DBPanel() : base() {
            DoubleBuffered = true;
        }
    }
}
