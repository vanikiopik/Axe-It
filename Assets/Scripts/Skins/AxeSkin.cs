using System.Collections.Generic;
using Axe;
using GUI.GuiHandler.SkinMenuHUD.SkinViews;
using UnityEngine;

namespace Skins
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "Axe", menuName = "Items/Axe")]
    public class AxeSkin : Skin
    {
        [field: Header("Graphics")]
        [field: SerializeField] public Mesh Mesh { get; set; }
        [field: SerializeField] public List<Material> Materials { get; set; }

        public override void LoadGraphic<T>(List<SkinView<T>> views) =>
            FindObjectOfType<AxeEngine>()?.LoadGraphics(this);
    }
}
