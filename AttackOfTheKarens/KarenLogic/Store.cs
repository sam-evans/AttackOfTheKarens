using System.Windows.Forms;

namespace KarenLogic {
    public class Store {
        private Karen karen;
        private bool containsOwner;

        public Store(Karen karen) {
            this.karen = karen;
        }

        /// <summary>
        /// Returns true if the Karen is in the defeated state.
        /// </summary>
        /// <returns></returns>
        public bool IsDefeated() { return this.karen.IsDefeated; }
        /// <summary>
        /// Return the Y position of the Karen.
        /// </summary>
        /// <returns></returns>
        public int GetTop() { return this.karen.GetTop(); }
        /// <summary>
        /// Return the X position of the Karen.
        /// </summary>
        /// <returns></returns>
        public int GetLeft() { return this.karen.GetLeft(); }
        /// <summary>
        /// Reset the Karen back to not defeated.
        /// </summary>
        public void Reset() { this.karen.Reset(); }
        /// <summary>
        /// Gets how much money the defeated Karen earned you.
        /// </summary>
        public float GetScore() { return this.karen.Score; }
        /// <summary>
        /// Get the level of the Karen that just spawned.
        /// </summary>
        public int GetLevel() { return this.karen.Level; }
        /// <summary>
        /// Get the PictureBox of the Karen.
        /// </summary>
        /// <returns></returns>
        public PictureBox GetKarenPB() { return this.karen.pic; }

        public void ActivateTheKaren() {
            karen.Appear();
        }

        public void OwnerWalksIn() {
            containsOwner = true;
        }

        public void ResetOwner() {
            containsOwner = false;
        }

        public void Update() {
            if (karen.IsPresent && containsOwner) {
                karen.Damage(1);
            }
        }
    }
}
