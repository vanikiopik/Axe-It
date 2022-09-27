using UnityEngine;
using UnityEngine.UI;

namespace GUI.PauseMenuHUD
{
    public class PauseMenuView : UiView
    {
        [field: SerializeField] public Text ScoreInfoText { get; set; }
        [field: SerializeField] public Button CloseButton { get; set; }
        [field: SerializeField] public Button ExitButton { get; set; }
    }
}