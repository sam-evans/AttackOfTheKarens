using KarenLogic;
using System;
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
                //TODO: Need to do some kind of game reset function when an upgrade is selceted.
            }
            // If the user cannot prestige yet, it shows a warning message.
            else
            {
                DiableButtonsUntilPrestigeIsAvalible();
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

        private void DiableButtonsUntilPrestigeIsAvalible()
        {
            PrestigeNotEnoughMoneyText.Visible = true;
            // If the user still has the window open by the time they can prestige, it hides the warning
            if (CheckIfCanPrestige())
            {
                PrestigeNotEnoughMoneyText.Visible = false;
            }
        }

    }
}
