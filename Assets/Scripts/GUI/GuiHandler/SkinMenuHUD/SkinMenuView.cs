using UnityEngine;
using UnityEngine.UI;
using Button = UnityEngine.UI.Button;

namespace GUI.GuiHandler.SkinMenuHUD
{
    public class SkinMenuView : UiView
    {
        [field: SerializeField] public Button CloseButton { get; set; }
        
        [field: Header("Buttons")]
        [field: SerializeField] public Outline AxeOutline { get; set; }
        [field: SerializeField] public Outline ThemeOutline { get; set; }

        [field: Header("Buttons")]
        [field: SerializeField] public Button AxeButton { get; set; }
        [field: SerializeField] public Button ThemeButton { get; set; }
        
        [field: Header("Scroll View's")]
        [field: SerializeField] public ScrollRect AxeScrollView { get; set; }
        [field: SerializeField] public ScrollRect ThemeScrollView { get; set; }
    }
}