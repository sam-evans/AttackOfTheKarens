using System.Collections.Generic;
using System.Windows.Forms;

namespace KarenLogic {
  public static class Game {
    public static float Score { get; set; }
    public static List<Form> openForms;

    static Game() {
      openForms = new List<Form>();
    }

    public static void AddToScore(float amount) {
      Score += amount;
    }

    public static void CloseAll() {
      for (int i = 0; i < openForms.Count; i++) {
        openForms[i].Close();
      }
    }
  }
}
