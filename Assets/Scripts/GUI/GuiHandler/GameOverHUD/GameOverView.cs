using UnityEngine;
using UnityEngine.UI;

namespace GUI.GuiHandler.GameOverHUD
{
    public class GameOverView : UiView
    {
        [field: SerializeField] public ScalableText ReviveText { get; set; }
        [field: SerializeField] public Text ScoreText { get; set; }
        [field: SerializeField] public Button ADWatchButton { get; set; }
        [field: SerializeField] public Button ExitButton { get; set; }
        [field: SerializeField] public Button CloseButton { get; set; }
    }
}