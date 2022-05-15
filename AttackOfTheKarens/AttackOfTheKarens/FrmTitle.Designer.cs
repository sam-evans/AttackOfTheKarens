namespace AttackOfTheKarens {
  partial class FrmTitle {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent() {

      
        this.btnStart = new System.Windows.Forms.Button();
        this.btnMute = new System.Windows.Forms.Button();
        this.SuspendLayout();
        // 
        // btnStart
        // 
        this.btnStart.AutoSize = true;
        this.btnStart.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.btnStart.Location = new System.Drawing.Point(420, 563);
        this.btnStart.Name = "btnStart";
        this.btnStart.Size = new System.Drawing.Size(291, 75);
        this.btnStart.TabIndex = 0;
        this.btnStart.Text = "Start Game";
        this.btnStart.UseVisualStyleBackColor = true;
        this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
        // 
        // btnMute
        this.btnMute.AutoSize = true;
        this.btnMute.Font = new System.Drawing.Font("Segoe UI", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
        this.btnMute.Location = new System.Drawing.Point(0, 563);
        this.btnMute.Name = "btnMute";
        this.btnMute.Size = new System.Drawing.Size(75, 75);
        this.btnMute.TabIndex = 0;
        this.btnMute.Text = "Mute";
        this.btnMute.UseVisualStyleBackColor = true;
        this.btnMute.Click += new System.EventHandler(this.btnMute_Click);
        //
        // FrmTitle
        // 
        this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
        this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
        this.BackColor = System.Drawing.Color.Black;
        this.BackgroundImage = global::AttackOfTheKarens.Properties.Resources.title;
        this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
        this.ClientSize = new System.Drawing.Size(1126, 669);
        this.Controls.Add(this.btnStart);
        this.Controls.Add(this.btnMute);
        this.DoubleBuffered = true;
        this.Name = "FrmTitle";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "FrmTitle";
        this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmTitle_FormClosed);
        this.Load += new System.EventHandler(this.FrmTitle_Load);
        this.ResumeLayout(false);
        this.PerformLayout();

    }

    #endregion

    private System.Windows.Forms.Button btnStart;
    private System.Windows.Forms.Button btnMute;
  }
}