using System.Windows.Forms;
using System.Drawing;

namespace KarenLogic {

    /// <summary>
    /// TODO: write a comment here
    /// </summary>
    public class Karen {
        public int Row { get; set; }
        public int Col { get; set; }
        public int Health { get; private set; }
        public int maxHealth;
        public bool IsPresent { get; private set; }
        public bool IsDefeated { get; private set; }
        public int Level { get; private set; }
        public float Score { get; private set; }

        public int GetTop() { return pic.Top; }
        public int GetLeft() { return pic.Left; }
        public void Reset() { this.IsDefeated = false; }

        public PictureBox pic;
        public PictureBox health;
        public Karen(PictureBox pic, PictureBox health) {
            this.pic = pic;
            this.health = health;
            this.pic.Visible = false;
            this.health.Visible = false;
            this.IsPresent = false;
            this.IsDefeated = false;
            this.Health = 10;
            this.maxHealth = this.Health;
        }

        public void Appear() {
            if (this.IsPresent) { return; }

            this.pic.Visible = true;
            this.health.Visible = true;
            this.IsPresent = true;
            this.pic.BringToFront();

            //set a random level from 0 to 3
            System.Random random = new System.Random();
            this.Level = random.Next(0, 4);

            this.Health = 20 + 20 * Level;
            this.maxHealth = this.Health;
        }

        public void Damage(int amount) {
            Health -= amount;
            if (Health < 0) {
                
                //create a random score from 4 to 6 dollars.
                System.Random random = new System.Random();
                float randF = (float)random.NextDouble();
                int randI = random.Next(4, 7);
                float score = randI + randF;

                //score is multiplied based off of karen level and prestige level
                score = score + score * Level;
                score *= Game.PrestigeMoneyMultiplier;

                Game.AddToScore(score);
                this.Score = score;
                this.pic.Visible = false;
                this.health.Visible = false;
                this.IsPresent = false;
                this.IsDefeated = true;
            }
        }
    }
}
