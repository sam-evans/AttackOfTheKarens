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
        public bool IsPresent { get; private set; }
        public bool IsDefeated { get; private set; }
        public int Level { get; private set; }
        public float Score { get; private set; }

        public int GetTop() { return pic.Top; }
        public int GetLeft() { return pic.Left; }
        public void Reset() { this.IsDefeated = false; }

        public PictureBox pic;
        public Karen(PictureBox pic) {
            this.pic = pic;
            this.pic.Visible = false;
            this.IsPresent = false;
            this.IsDefeated = false;
            this.Health = 10;
        }

        public void Appear() {
            if (this.IsPresent) { return; }

            this.pic.Visible = true;
            this.IsPresent = true;
            this.pic.BringToFront();

            //set a random level from 0 to 3
            System.Random random = new System.Random();
            this.Level = random.Next(0, 4);
        }

        public void Damage(int amount) {
            Health -= amount;
            if (Health < 0) {
                
                //create a random score from 4 to 6 dollars.
                System.Random random = new System.Random();
                float randF = (float)random.NextDouble();
                int randI = random.Next(4, 7);

                //score is multiplied based off of karen level
                float score = (randI+randF)*Level;

                Game.AddToScore(score);
                this.Score = score;
                this.pic.Visible = false;
                this.IsPresent = false;
                this.IsDefeated = true;
            }
        }
    }
}
