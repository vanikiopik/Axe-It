using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;
using Slider = UnityEngine.UI.Slider;

namespace GUI.GuiHandler.GameHUD
{
    public class GameView : UiView
    {
        [field: SerializeField] public Slider Slider { get; set; }
        [field: SerializeField] public RectTransform WinArea { get; set; }
        [field: SerializeField] public RectTransform Handle { get; set; }
        [field: SerializeField] public Text ScoreText { get; set; }
        [field: SerializeField] public Button PauseButton { get; set; }
    }
}