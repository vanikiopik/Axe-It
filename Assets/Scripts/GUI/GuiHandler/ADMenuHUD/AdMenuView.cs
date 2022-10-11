using UnityEngine;
using UnityEngine.UI;

namespace GUI.GuiHandler.ADMenuHUD
{
    public class AdMenuView : UiView
    {
        [field: SerializeField] public Button CloseButton { get; set; }
        [field: SerializeField] public Button AdWatchButton { get; set; }
    }
}