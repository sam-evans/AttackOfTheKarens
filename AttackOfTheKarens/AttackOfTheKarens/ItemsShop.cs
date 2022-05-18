using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AttackOfTheKarens
{
    public partial class ItemsShop : Form
    {
        public ItemsShop()
        {
            InitializeComponent();
        }

        float WipeCost = 15f;
        float CharismaCost = 15f;
        float BonusCashCost = 15f;
        
        private void KarenBoardWipeButton_Click(object sender, EventArgs e)
        {
            //TODO: Wipe board of karens on button click if player has enough money.
            //Optional: Show the "not enough money" if player doesn't have enough. Also Could be time limited
            if (KarenLogic.Game.Score > WipeCost) {
                FrmMall.WipeButton();
                
                KarenLogic.Game.Score -= WipeCost;
                WipeCost += 15f;
            }
               
            
        }
        int i = 5;
        /*private void OwnerSpeedIncreaseButton_Click(object sender, EventArgs e)
        {
            //TODO: Increase owners speed on button click if player has enough money.
            //Optional: Show the "not enough money" if player doesn't have enough. Also Could be time limited
            
        }*/

        private void BetterSuccessAgainstKarenButton_Click(object sender, EventArgs e)
        {
            //TODO: owner gets better success against karens on button click if player has enough money.
            //Optional: Show the "not enough money" if player doesn't have enough. Also Could be time limited
            if (KarenLogic.Game.Score > CharismaCost)
            {
                FrmMall.Charisma(i);
                KarenLogic.Game.Score -= CharismaCost;
                CharismaCost += 15f;
                i += 5;
            }
        }
        float bonus=5f;
        private void GetMoreMoneyButton_Click(object sender, EventArgs e)
        {
            //TODO: Give a multiplier to "score" on button click if player has enough money.
            //Optional: Show the "not enough money" if player doesn't have enough. Also Could be time limited

            if (KarenLogic.Game.Score > BonusCashCost)
            {
                KarenLogic.Game.BonusCash += 5;
                KarenLogic.Game.Score -= BonusCashCost;
            }
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
