using UnityEngine;
using UnityEngine.UI;

namespace GUI.MoneyTableHUD
{
    public class MoneyTableHudView : UiView
    {
        [field: SerializeField] public Image Background { get; set; }
        [field: SerializeField] public Text MoneyText { get; set; }
        [field: SerializeField] public Button PlusButton { get; set; }
    }
}
