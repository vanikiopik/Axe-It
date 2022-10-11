using System.Collections.Generic;
using Skins;
using UnityEngine;

namespace GUI.GuiHandler.SkinMenuHUD.SkinViews.Container
{
    public abstract class SkinViewContainer<T> : MonoBehaviour where T : Skin
    {
        [SerializeField] private SkinView<T> _prefab;
        [SerializeField] protected List<T> _skins;

        public void Initialize()
        {
            TryLoadModels();
            List<SkinView<T>> views = new List<SkinView<T>>();
            for (int i = 0; i < _skins.Count; i++)
                views.Add(Instantiate(_prefab, transform));

            for (int i = 0; i < _skins.Count; i++)
                views[i].Initialize(_skins[i], views);
            
            FindSelectedOrBought(views)?.Select();
        }

        private SkinView<T> FindSelectedOrBought(List<SkinView<T>> views)
        {
            SkinView<T> currentSkin = views.Find(controller => controller.Model.IsSelected);
            if (currentSkin == null)
                currentSkin = views.Find(controller => controller.Model.IsBought);
            return currentSkin;
        }

        protected abstract void TryLoadModels();
    }
}
