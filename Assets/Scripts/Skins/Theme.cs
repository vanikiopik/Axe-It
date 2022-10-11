using System.Collections.Generic;
using GUI.GuiHandler.SkinMenuHUD.SkinViews;
using UnityEngine;

namespace Skins
{
    [System.Serializable]
    [CreateAssetMenu(fileName = "Theme", menuName = "Items/Theme")]
    public class Theme : Skin
    {
        [field: Header("Graphics")]
        [SerializeField] private GameObject _prefab;

        private GameObject _theme;

        public override void LoadGraphic<T>(List<SkinView<T>> views)
        {
            foreach (var view in views)
            {
                GameObject theme = (view.Model as Theme)?._theme;
                if (theme != null) Destroy(theme);
            }

            if (_theme == null) _theme = Instantiate(_prefab);
            _theme.SetActive(true);
        }
    }
}
