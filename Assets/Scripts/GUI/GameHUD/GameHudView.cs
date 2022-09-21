using UnityEngine;
using UnityEngine.UI;

namespace GUI.GameHUD
{
    public class GameHudView : UiView
    {
        [field: SerializeField] public Slider Slider { get; set; }
        [field: SerializeField] public RectTransform FillArea { get; set; }
        [field: SerializeField] public RectTransform Handle { get; set; }
        [field: SerializeField] public Text ScoreText { get; set; }
        [field: SerializeField] public Button PauseButton { get; set; }
    }
}
