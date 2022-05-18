using KarenLogic;
using System;
using static AttackOfTheKarens.FrmMall;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttackOfTheKarens
{
    public partial class PrestigeMenu : Form
    {
        public static bool lablesReset;
        public PrestigeMenu()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Doubles the perminate Prestige money multiplier, or shows a warning that they have not gathered enough money to Prestige.
        /// </summary>

        private void PrestigeMoneyMultiplierButton_Click(object sender, EventArgs e)
        {
            // If the user can prestige, it doubles the multiplier
            if (CheckIfCanPrestige())
            {
                Game.PrestigeMoneyMultiplier *= 2;
                ResetAfterPrestige();
            }
            // If the user cannot prestige yet, it shows a warning message.
            else
            {
                PrestigeNotEnoughMoneyText.Visible = true;
            }

        }

        /// <summary>
        /// Increases the percent chance that the owner will succeed. 
        /// </summary>

        private void PrestigePercentChanceButton_Click(object sender, EventArgs e)
        {
            //TODO: Increase the chance to defeat karens
            //TODO: Need to do somekind of game reset function when an upgrade is selceted.
            //TODO: something to warn the player they need a certain amount of money before they can prestige and to increase the amount needed for the next prestige
        }
        /// <summary>
        /// Changes the default movement algorithm to the improved algorithm
        /// </summary>

        private void PrestigeOwnerMovementButton_Click(object sender, EventArgs e)
        {
            //TODO: Switch to the better pathfinding algorithm (Should only allow the user to do this once)
            //TODO: Need to do somekind of game reset function when an upgrade is selceted.
            //TODO: something to warn the player they need a certain amount of money before they can prestige and to increase the amount needed for the next prestige
        }

        /// <summary>
        /// To check the current score against the Prestige Condition. If the user has enough score, they can "purchase" an upgrade.
        /// </summary>
        /// <returns></returns>
        private bool CheckIfCanPrestige()
        {
            // Check if the score is less than the needed score to prestige.
            if (Game.Score < Game.PrestigeMenuCondition)
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        /// <summary>
        /// Resets the game except for the prestige upgrades. Increases the condition to get the next prestige
        /// </summary>
        private void ResetAfterPrestige()
        {
            Game.PrestigeMenuCondition *= 10;
            Game.PrestigeLevel++;
            Game.Score = 0;
            Game.BonusCash = 0;
            Store._damage = 1;

            FrmMall.UpdateLabels();
            FrmMall.TurnOnFireworks();
            
        }
        public static int i = 0;
        public static bool isPrestiged()
        {
            if (Game.PrestigeLevel > i){
                i = Game.PrestigeLevel;
                return true;
                
            }
            return false;
                
            
        }

        private void PrestigeNotEnoughMoneyText_Click(object sender, EventArgs e)
        {

        }
    }
}
