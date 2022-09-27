using UnityEngine;
using UnityEngine.UI;

namespace GUI.GameOverHUD
{
    public class GameOverView : UiView
    {
        [field: SerializeField] public Text ScoreInfoText { get; set; }
        [field: SerializeField] public Button ADWatchButton { get; set; }
        [field: SerializeField] public Button PayButton { get; set; }
        [field: SerializeField] public Button ExitButton { get; set; }
        [field: SerializeField] public Button CloseButton { get; set; }
    }
}