using UnityEngine;
using UnityEngine.UI;

namespace GUI.GuiHandler.MainMenuHUD
{
    public class MainMenuView : UiView
    {
        [field: SerializeField] public ScalableText StartText { get; private set; }
        [field: SerializeField] public Text BestRecordText { get; private set; }
        [field: SerializeField] public Text BonusCooldownText { get; private set; }
        
        [field: Header("Buttons")]
        [field: SerializeField] public Button PlayButton { get; private set; }
        [field: SerializeField] public Button SoundButton { get; private set; }
        [field: SerializeField] public Button SkinButton { get; private set; }
        [field: SerializeField] public Button BonusButton { get; private set; }

        [field: Header("Sound Sprites")]
        [field: SerializeField] public Sprite SoundOnSprite { get; private set; }
        [field: SerializeField] public Sprite SoundOffSprite { get; private set; }
    }
}