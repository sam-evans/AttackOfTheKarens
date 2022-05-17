using System.Collections.Generic;
using System.Windows.Forms;

namespace KarenLogic {
    public static class Game {
        public static float Score { get; set; }
        public static int PrestigeMoneyMultiplier { get; set; }
        public static float PrestigeMenuCondition { get; set; }
        public static int PrestigeLevel { get; set; }

        public static List<Form> openForms;

        static Game() {
            openForms = new List<Form>();
            PrestigeLevel = 0;
            PrestigeMoneyMultiplier = 1;
            PrestigeMenuCondition = 15f;
        }

        public static void AddToScore(float amount) { Score += amount; }

        public static void CloseAll() { for (int i = 0; i < openForms.Count; i++) { openForms[i].Close(); } }
    }
}
