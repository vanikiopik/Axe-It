using UnityEngine;
using UnityEngine.UI;

namespace GUI.GuiHandler.SkinMenuHUD
{
    public class SkinMenuView : UiView
    {
        [field: SerializeField] public Button CloseButton { get; private set; }
        
        [field: Header("Buttons")]
        [field: SerializeField] public Outline AxeOutline { get; private set; }
        [field: SerializeField] public Outline ThemeOutline { get; private set; }

        [field: Header("Buttons")]
        [field: SerializeField] public Button AxeButton { get; private set; }
        [field: SerializeField] public Button ThemeButton { get; private set; }
        
        [field: Header("Scroll View's")]
        [field: SerializeField] public ScrollRect AxeScrollView { get; private set; }
        [field: SerializeField] public ScrollRect ThemeScrollView { get; private set; }
    }
}