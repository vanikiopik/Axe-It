using UnityEngine;
using UnityEngine.UI;

namespace GUI.MainMenuHUD
{
    public class MainMenuHudView : UiView
    {
        [field: SerializeField] public Text StartText { get; set; }
        [field: SerializeField] public Text BestRecordText { get; set; }
        [field: SerializeField] public Text BonusCooldownText { get; set; }
        [field: SerializeField] public Image SoundButtonImage { get; set; }
        [field: SerializeField] public Image SkinMenuButton { get; set; }
        [field: SerializeField] public Image BonusButton { get; set; }
        [field: SerializeField] public Sprite SoundOnSprite { get; set; }
        [field: SerializeField] public Sprite SoundOffSprite { get; set; }
    }
}
