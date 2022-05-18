using System;
using System.Windows.Forms;

namespace AttackOfTheKarens
{
    partial class PrestigeMenu
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.PrestigeMoneyMultiplierButton = new System.Windows.Forms.Button();
            this.PrestigePercentChanceButton = new System.Windows.Forms.Button();
            this.PrestigeOwnerMovementButton = new System.Windows.Forms.Button();
            this.QuitPrestigeMenuButton = new System.Windows.Forms.Button();
            this.PrestigeMenuTitleText = new System.Windows.Forms.Label();
            this.PrestigeWarningText = new System.Windows.Forms.Label();
            this.PrestigeNotEnoughMoneyText = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // PrestigeMoneyMultiplierButton
            // 
            this.PrestigeMoneyMultiplierButton.Location = new System.Drawing.Point(12, 60);
            this.PrestigeMoneyMultiplierButton.Name = "PrestigeMoneyMultiplierButton";
            this.PrestigeMoneyMultiplierButton.Size = new System.Drawing.Size(182, 58);
            this.PrestigeMoneyMultiplierButton.TabIndex = 2;
            this.PrestigeMoneyMultiplierButton.Text = "Upgrade Money Multiplier (x2)";
            this.PrestigeMoneyMultiplierButton.UseVisualStyleBackColor = true;
            this.PrestigeMoneyMultiplierButton.Click += new System.EventHandler(this.PrestigeMoneyMultiplierButton_Click);
            // 
            // PrestigePercentChanceButton
            // 
            this.PrestigePercentChanceButton.Location = new System.Drawing.Point(252, 60);
            this.PrestigePercentChanceButton.Name = "PrestigePercentChanceButton";
            this.PrestigePercentChanceButton.Size = new System.Drawing.Size(182, 58);
            this.PrestigePercentChanceButton.TabIndex = 3;
            this.PrestigePercentChanceButton.Text = "Upgrade Damage To Karens";
            this.PrestigePercentChanceButton.UseVisualStyleBackColor = true;
            this.PrestigePercentChanceButton.Click += new System.EventHandler(this.PrestigePercentChanceButton_Click);
            // 
            // PrestigeOwnerMovementButton
            // 
            this.PrestigeOwnerMovementButton.Location = new System.Drawing.Point(486, 60);
            this.PrestigeOwnerMovementButton.Name = "PrestigeOwnerMovementButton";
            this.PrestigeOwnerMovementButton.Size = new System.Drawing.Size(182, 58);
            this.PrestigeOwnerMovementButton.TabIndex = 4;
            this.PrestigeOwnerMovementButton.Text = "Upgrade Owners Movement";
            this.PrestigeOwnerMovementButton.UseVisualStyleBackColor = true;
            this.PrestigeOwnerMovementButton.Click += new System.EventHandler(this.PrestigeOwnerMovementButton_Click);
            // 
            // QuitPrestigeMenuButton
            // 
            this.QuitPrestigeMenuButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.QuitPrestigeMenuButton.Location = new System.Drawing.Point(309, 161);
            this.QuitPrestigeMenuButton.Name = "QuitPrestigeMenuButton";
            this.QuitPrestigeMenuButton.Size = new System.Drawing.Size(75, 23);
            this.QuitPrestigeMenuButton.TabIndex = 5;
            this.QuitPrestigeMenuButton.Text = "Done";
            this.QuitPrestigeMenuButton.UseVisualStyleBackColor = true;
            // 
            // PrestigeMenuTitleText
            // 
            this.PrestigeMenuTitleText.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PrestigeMenuTitleText.Location = new System.Drawing.Point(227, 9);
            this.PrestigeMenuTitleText.Name = "PrestigeMenuTitleText";
            this.PrestigeMenuTitleText.Size = new System.Drawing.Size(241, 48);
            this.PrestigeMenuTitleText.TabIndex = 6;
            this.PrestigeMenuTitleText.Text = "Prestige Menu";
            // 
            // PrestigeWarningText
            // 
            this.PrestigeWarningText.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.PrestigeWarningText.Location = new System.Drawing.Point(37, 121);
            this.PrestigeWarningText.Name = "PrestigeWarningText";
            this.PrestigeWarningText.Size = new System.Drawing.Size(619, 37);
            this.PrestigeWarningText.TabIndex = 7;
            this.PrestigeWarningText.Text = "Warning: Prestige will reset your progress to the beginning, but you will keep yo" +
    "ur prestige upgrade";
            // 
            // PrestigeNotEnoughMoneyText
            // 
            this.PrestigeNotEnoughMoneyText.BackColor = System.Drawing.SystemColors.ActiveCaptionText;
            this.PrestigeNotEnoughMoneyText.Font = new System.Drawing.Font("Segoe UI", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.PrestigeNotEnoughMoneyText.ForeColor = System.Drawing.Color.Red;
            this.PrestigeNotEnoughMoneyText.Location = new System.Drawing.Point(12, 60);
            this.PrestigeNotEnoughMoneyText.Name = "PrestigeNotEnoughMoneyText";
            this.PrestigeNotEnoughMoneyText.Size = new System.Drawing.Size(656, 58);
            this.PrestigeNotEnoughMoneyText.TabIndex = 8;
            this.PrestigeNotEnoughMoneyText.Text = "Don\'t have enough money to Prestige";
            this.PrestigeNotEnoughMoneyText.Visible = false;
            // 
            // PrestigeMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(680, 196);
            this.Controls.Add(this.PrestigeNotEnoughMoneyText);
            this.Controls.Add(this.PrestigeWarningText);
            this.Controls.Add(this.PrestigeMenuTitleText);
            this.Controls.Add(this.QuitPrestigeMenuButton);
            this.Controls.Add(this.PrestigeOwnerMovementButton);
            this.Controls.Add(this.PrestigePercentChanceButton);
            this.Controls.Add(this.PrestigeMoneyMultiplierButton);
            this.Name = "PrestigeMenu";
            this.Text = "PrestigeMenu";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button PrestigeMoneyMultiplierButton;
        private System.Windows.Forms.Button PrestigePercentChanceButton;
        private System.Windows.Forms.Button PrestigeOwnerMovementButton;
        private System.Windows.Forms.Button QuitPrestigeMenuButton;
        private Label PrestigeMenuTitleText;
        private Label PrestigeWarningText;
        private Label PrestigeNotEnoughMoneyText;
    }
}