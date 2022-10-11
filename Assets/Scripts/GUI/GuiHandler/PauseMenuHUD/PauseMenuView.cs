using UnityEngine;
using UnityEngine.UI;

namespace GUI.GuiHandler.PauseMenuHUD
{
    public class PauseMenuView : UiView
    {
        [field: SerializeField] public Text ScoreText { get; set; }
        [field: SerializeField] public Button CloseButton { get; set; }
        [field: SerializeField] public Button ExitButton { get; set; }
    }
}