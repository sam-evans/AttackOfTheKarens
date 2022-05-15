using System.Windows.Forms;

namespace KarenLogic {

    /// <summary>
    /// TODO: write a comment here
    /// </summary>
    public class Karen {

        /// <summary>
        /// The pixel location of the row Karen is on
        /// </summary>
        public int Row { get; set; }
        public int Col { get; set; }
        public int Health { get; private set; }
        public bool IsPresent { get; private set; }

        public float score = 0;

        /// <summary>
        /// If a Karen has just been defeated, this will return true until the dollar animation has begun.
        /// </summary>
        public bool IsDefeated { get; private set; }

        /// <summary>
        /// This is the image of Karen
        /// </summary>
        public PictureBox pic;

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="pic">The PictureBox container for Karen</param>
        public Karen(PictureBox pic) {
            this.pic = pic;
            this.pic.Visible = false;
            this.IsPresent = false;
            this.IsDefeated = false;
            this.Health = 10;
        }

        public void Appear() {
            this.pic.Visible = true;
            this.IsPresent = true;
            this.pic.BringToFront();
        }

        public void Damage(int amount) {
            Health -= amount;
            if (Health < 0) {
                
                //create a random score from 4 to 6 dollars.
                System.Random random = new System.Random();
                float randF = (float)random.NextDouble();
                int randI = random.Next(4, 7);
                float score = randI+randF;

                Game.AddToScore(score);
                this.score = score;
                this.pic.Visible = false;
                this.IsPresent = false;
                this.IsDefeated = true;
            }
        }

        /// <summary>
        /// Get the Y position of the Karen.
        /// </summary>
        /// <returns></returns>
        public int GetTop() { return pic.Top; }
        /// <summary>
        /// Get the X position of the Karen.
        /// </summary>
        /// <returns></returns>
        public int GetLeft() { return pic.Left; }
        /// <summary>
        /// Set the Karen back to not defeated.
        /// </summary>
        public void Reset() { this.IsDefeated = false; }
        /// <summary>
        /// Gets how much money the defeated Karen earned you.
        /// </summary>
        /// <returns></returns>
        public float GetScore() { return score; }
    }
}
