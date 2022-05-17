using System.Windows.Forms;

namespace KarenLogic {
    public class Store {
        private Karen karen;
        private bool containsOwner;

        public Store(Karen karen) {
            this.karen = karen;
        }

        //position of the karen
        public int GetTop() { return this.karen.GetTop(); }
        public int GetLeft() { return this.karen.GetLeft(); }

        //whether or not a karen was just defeated
        public bool IsDefeated() { return this.karen.IsDefeated; }

        //reset the karen back to not defeated
        public void Reset() { this.karen.Reset(); }

        //getters
        public float GetScore() { return this.karen.Score; }
        public int GetLevel() { return this.karen.Level; }
        public PictureBox GetKarenPB() { return this.karen.pic; }
        public PictureBox GetHealthPB() { return this.karen.health; }

        //determine what image the health bar should be
        public int getHealthBars() { return this.karen.Health * 8 / this.karen.maxHealth; }

        //spawn a karen
        public void ActivateTheKaren() { karen.Appear(); }

        //change whether owner is inside or outside of store
        public void OwnerWalksIn() { containsOwner = true; }
        public void ResetOwner() { containsOwner = false; }

        //update karen hp
        public void Update() {
            if (karen.IsPresent && containsOwner) {
                karen.Damage(1);
            }
        }
    }
}
