using UnityEngine;
using UnityEngine.UI;

namespace GUI.GuiHandler.PauseMenuHUD
{
    public class PauseMenuView : UiView
    {
        [field: SerializeField] public Text ScoreText { get; private set; }
        [field: SerializeField] public Button CloseButton { get; private set; }
        [field: SerializeField] public Button ExitButton { get; private set; }
    }
}