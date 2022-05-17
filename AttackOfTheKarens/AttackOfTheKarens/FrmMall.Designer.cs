using System.Windows.Forms;

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
            this.lblPrestige = new System.Windows.Forms.Label();
            this.lblMoneySaved = new System.Windows.Forms.Label();
            this.lblMoneySavedLabel = new System.Windows.Forms.Label();
            this.lblMoneyFeed1 = new System.Windows.Forms.Label();
            this.lblMoneyFeed2 = new System.Windows.Forms.Label();
            this.lblMoneyFeed3 = new System.Windows.Forms.Label();
            this.lblMoneyFeed4 = new System.Windows.Forms.Label();
            this.lblMoneyFeed5 = new System.Windows.Forms.Label();
            this.tmrUpdateGame = new System.Windows.Forms.Timer(this.components);
            this.PrestigeMenuButton = new System.Windows.Forms.Button();
            this.MuteButton = new System.Windows.Forms.Button();
            this.ItemsShopButton = new System.Windows.Forms.Button();
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
            this.lblMoneySaved.Size = new System.Drawing.Size(84, 32);
            this.lblMoneySaved.TabIndex = 1;
            this.lblMoneySaved.Text = "$ 0.00";
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
            // lblPrestige
            //
            this.lblPrestige.AutoSize = true;
            this.lblPrestige.Font = new System.Drawing.Font("Segoe UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblPrestige.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(0)))));
            this.lblPrestige.Location = new System.Drawing.Point(917, 6);
            this.lblPrestige.Name = "lblPrestige";
            this.lblPrestige.Size = new System.Drawing.Size(137, 25);
            this.lblPrestige.TabIndex = 2;
            this.lblPrestige.Text = "Prestige: 0";
            this.lblPrestige.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMoneyFeed1
            // 
            this.lblMoneyFeed1.AutoSize = true;
            this.lblMoneyFeed1.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMoneyFeed1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblMoneyFeed1.Location = new System.Drawing.Point(1075, -1);
            this.lblMoneyFeed1.Name = "lblMoneyFeed1";
            this.lblMoneyFeed1.Size = new System.Drawing.Size(0, 32);
            this.lblMoneyFeed1.TabIndex = 1;
            this.lblMoneyFeed1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMoneyFeed2
            // 
            this.lblMoneyFeed2.AutoSize = true;
            this.lblMoneyFeed2.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMoneyFeed2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblMoneyFeed2.Location = new System.Drawing.Point(1075, -1);
            this.lblMoneyFeed2.Name = "lblMoneyFeed2";
            this.lblMoneyFeed2.Size = new System.Drawing.Size(0, 32);
            this.lblMoneyFeed2.TabIndex = 1;
            this.lblMoneyFeed2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMoneyFeed3
            // 
            this.lblMoneyFeed3.AutoSize = true;
            this.lblMoneyFeed3.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMoneyFeed3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblMoneyFeed3.Location = new System.Drawing.Point(1075, -1);
            this.lblMoneyFeed3.Name = "lblMoneyFeed3";
            this.lblMoneyFeed3.Size = new System.Drawing.Size(0, 32);
            this.lblMoneyFeed3.TabIndex = 1;
            this.lblMoneyFeed3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMoneyFeed4
            // 
            this.lblMoneyFeed4.AutoSize = true;
            this.lblMoneyFeed4.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMoneyFeed4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblMoneyFeed4.Location = new System.Drawing.Point(1075, -1);
            this.lblMoneyFeed4.Name = "lblMoneyFeed4";
            this.lblMoneyFeed4.Size = new System.Drawing.Size(0, 32);
            this.lblMoneyFeed4.TabIndex = 1;
            this.lblMoneyFeed4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblMoneyFeed5
            // 
            this.lblMoneyFeed5.AutoSize = true;
            this.lblMoneyFeed5.Font = new System.Drawing.Font("Segoe UI", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblMoneyFeed5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
            this.lblMoneyFeed5.Location = new System.Drawing.Point(1075, -1);
            this.lblMoneyFeed5.Name = "lblMoneyFeed5";
            this.lblMoneyFeed5.Size = new System.Drawing.Size(0, 32);
            this.lblMoneyFeed5.TabIndex = 1;
            this.lblMoneyFeed5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // MuteButton
            // 
            this.MuteButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.MuteButton.Location = new System.Drawing.Point(1084, 650);
            this.MuteButton.Name = "MuteButton";
            this.MuteButton.Size = new System.Drawing.Size(75, 23);
            this.MuteButton.TabIndex = 3;
            this.MuteButton.Text = "Mute";
            this.MuteButton.UseVisualStyleBackColor = true;
            this.MuteButton.Click += new System.EventHandler(this.MuteButton_Click);
            // 
            // ItemsShopButton
            // 
            this.ItemsShopButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.ItemsShopButton.Location = new System.Drawing.Point(1084, 369);
            this.ItemsShopButton.Name = "ItemsShopButton";
            this.ItemsShopButton.Size = new System.Drawing.Size(75, 23);
            this.ItemsShopButton.TabIndex = 4;
            this.ItemsShopButton.Text = "Shop";
            this.ItemsShopButton.UseVisualStyleBackColor = true;
            this.ItemsShopButton.Click += new System.EventHandler(this.ShopButton_Click);
            // 
            // FrmMall
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Black;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1171, 698);
            this.Controls.Add(this.ItemsShopButton);
            this.Controls.Add(this.MuteButton);
            this.Controls.Add(this.PrestigeMenuButton);
            this.Controls.Add(this.lblPrestige);
            this.Controls.Add(this.lblMoneySavedLabel);
            this.Controls.Add(this.lblMoneySaved);
            this.Controls.Add(this.lblMoneyFeed1);
            this.Controls.Add(this.lblMoneyFeed2);
            this.Controls.Add(this.lblMoneyFeed3);
            this.Controls.Add(this.lblMoneyFeed4);
            this.Controls.Add(this.lblMoneyFeed5);
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
    private System.Windows.Forms.Label lblPrestige;
    private System.Windows.Forms.Label lblMoneySaved;
    private System.Windows.Forms.Label lblMoneySavedLabel;
    private System.Windows.Forms.Label lblMoneyFeed1;
    private System.Windows.Forms.Label lblMoneyFeed2;
    private System.Windows.Forms.Label lblMoneyFeed3;
    private System.Windows.Forms.Label lblMoneyFeed4;
    private System.Windows.Forms.Label lblMoneyFeed5;
    private System.Windows.Forms.Timer tmrUpdateGame;

    /// <summary>
    /// Tick timer for animations. Executes every 100ms.
    /// </summary>
    private System.Windows.Forms.Timer tmrAnimationsUpdate;
    private System.Windows.Forms.Button PrestigeMenuButton;
        private Button MuteButton;
        private System.Windows.Forms.Button Mute;
        private Button ItemsShopButton;
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
