using UnityEngine;
using UnityEngine.UI;

namespace GUI.GuiHandler.MoneyPanelHUD
{
    public class MoneyPanelView : UiView
    {
        [field: SerializeField] public Text MoneyText { get; private set; }
        [field: SerializeField] public Button AddMoneyButton { get; private set; }
    }
}