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

        //spawn a karen
        public void Appear() {
            if (this.IsPresent) { return; }

            this.pic.Visible = true;
            this.health.Visible = true;
            this.IsPresent = true;
            this.pic.BringToFront();

            //create a random number from 1 to 100 to determine level of karen
            System.Random random = new System.Random();
            int RNG = random.Next(1, 101);

            //RNG number is increased based off of prestige level
            RNG += Game.PrestigeLevel * 50;

            //determine level of karen
            if (RNG <= 75) { this.Level = 0; }
            else if (RNG <= 125) { this.Level = 1; }
            else if (RNG <= 175) { this.Level = 2; }
            else { this.Level = 3; }

            //health is based off of karen level
            this.Health = 20 + 20 * Level;
            this.maxHealth = this.Health;
        }

        //instantly do as much damage to a karen as she has hp
        public void Defeat() {
            Damage(maxHealth+1);
        }

        //do damage to a karen and deal with her if she gets defeated
        public void Damage(int amount) {
            Health -= amount;
            if (Health < 0) {
                
                //create a random score from 4 to 6 dollars.
                System.Random random = new System.Random();
                float randF = (float)random.NextDouble();
                int randI = random.Next(4, 7);
                float score = randI + randF;

                //score is multiplied based off of karen level and prestige multiplier
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
