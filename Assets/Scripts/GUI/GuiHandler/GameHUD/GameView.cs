using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;
using Slider = UnityEngine.UI.Slider;

namespace GUI.GuiHandler.GameHUD
{
    public class GameView : UiView
    {
        [field: SerializeField] public Slider Slider { get; private set; }
        [field: SerializeField] public RectTransform WinArea { get; private set; }
        [field: SerializeField] public RectTransform Handle { get; private set; }
        [field: SerializeField] public Text ScoreText { get; private set; }
        [field: SerializeField] public Button PauseButton { get; private set; }
    }
}