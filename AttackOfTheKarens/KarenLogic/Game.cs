using System.Collections.Generic;
using System.Windows.Forms;

namespace KarenLogic {
  public static class Game {
    public static float Score { get; set; }
    public static List<Form> openForms;
        public static int PrestigeMoneyMultiplier { get; set; }
        public static float PrestigeMenuCondition { get; set; }

    static Game() {
      openForms = new List<Form>();
            PrestigeMoneyMultiplier = 1;
            PrestigeMenuCondition = 15f;
    }

    public static void AddToScore(float amount) {
      Score += amount * PrestigeMoneyMultiplier;
    }

    public static void CloseAll() {
      for (int i = 0; i < openForms.Count; i++) {
        openForms[i].Close();
      }
    }
  }
}
