using System.Collections.Generic;
using GUI.GuiHandler.SkinMenuHUD.SkinViews;
using UnityEngine;

namespace Skins
{
    [System.Serializable]
    public abstract class Skin : ScriptableObject
    {
        [field: SerializeField] public string Name { get; set; }
        [field: SerializeField] public Sprite Icon { get; set; }
        [field: SerializeField] public int Price { get; set; }
        [field: SerializeField] public bool IsBought { get; set; }
        [field: SerializeField] public bool IsSelected { get; set; }

        public abstract void LoadGraphic<T>(List<SkinView<T>> views) where T : Skin;
    }

    [System.Serializable]
    public class SkinData
    {
        public string Name { get; set; }
        public bool IsBought { get; set; }
        public bool IsSelected { get; set; }
    }
}