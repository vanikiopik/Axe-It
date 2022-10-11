using UnityEngine;
using UnityEngine.UI;

namespace GUI.GuiHandler.MainMenuHUD
{
    public class MainMenuView : UiView
    {
        [field: SerializeField] public ScalableText StartText { get; set; }
        [field: SerializeField] public Text BestRecordText { get; set; }
        [field: SerializeField] public Text BonusCooldownText { get; set; }
        
        [field: Header("Buttons")]
        [field: SerializeField] public Button PlayButton { get; set; }
        [field: SerializeField] public Button SoundButton { get; set; }
        [field: SerializeField] public Button SkinButton { get; set; }
        [field: SerializeField] public Button BonusButton { get; set; }

        [field: Header("Sound Sprites")]
        [field: SerializeField] public Sprite SoundOnSprite { get; set; }
        [field: SerializeField] public Sprite SoundOffSprite { get; set; }
    }
}
