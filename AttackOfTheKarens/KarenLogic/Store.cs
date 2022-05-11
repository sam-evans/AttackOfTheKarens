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
