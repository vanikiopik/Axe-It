using UnityEngine;
using UnityEngine.UI;

namespace GUI.GuiHandler.GameOverHUD
{
    public class GameOverView : UiView
    {
        [field: SerializeField] public ScalableText ReviveText { get; private set; }
        [field: SerializeField] public Text ScoreText { get; private set; }
        [field: SerializeField] public Button ADWatchButton { get; private set; }
        [field: SerializeField] public Button ExitButton { get; private set; }
        [field: SerializeField] public Button CloseButton { get; private set; }
    }
}