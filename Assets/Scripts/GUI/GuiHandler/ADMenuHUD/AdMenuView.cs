using UnityEngine;
using UnityEngine.UI;

namespace GUI.GuiHandler.ADMenuHUD
{
    public class AdMenuView : UiView
    {
        [field: SerializeField] public Text AwardAmountText { get; private set; }
        [field: SerializeField] public Button CloseButton { get; private set; }
        [field: SerializeField] public Button AdWatchButton { get; private set; }
        [field: SerializeField] public Text CooldownText { get; private set; }
    }
}