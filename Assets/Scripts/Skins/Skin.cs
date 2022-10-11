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

        public static List<SkinData> GetSkinsData<T>(List<T> skins) where T : Skin
        {
            List<SkinData> skinsData = new List<SkinData>();
            foreach (T skin in skins)
                skinsData.Add(new SkinData
                {
                    Name = skin.Name,
                    IsBought = skin.IsBought,
                    IsSelected = skin.IsSelected
                });
            return skinsData;
        }

        public static void SetSkinData<T>(List<T> skins, List<SkinData> skinsData) where T : Skin
        {
            for (int i = 0; i < skinsData.Count; i++)
            {
                if (skins[i].Name == skinsData[i].Name)
                {
                    skins[i].IsBought = skinsData[i].IsBought;
                    skins[i].IsSelected = skinsData[i].IsSelected;
                }
            }
        }
    }
}