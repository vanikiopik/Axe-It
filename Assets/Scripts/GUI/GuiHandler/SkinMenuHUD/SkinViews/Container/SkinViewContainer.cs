using System.Collections.Generic;
using Skins;
using UnityEngine;

namespace GUI.GuiHandler.SkinMenuHUD.SkinViews.Container
{
    public abstract class SkinViewContainer<T> : MonoBehaviour where T : Skin
    {
        [SerializeField] private SkinView<T> _prefab;
        [SerializeField] protected List<T> _skins;

        public void Initialize(MoneyCounter moneyCounter)
        {
            TryLoadModels();
            
            var views = new List<SkinView<T>>();
            for (int i = 0; i < _skins.Count; i++)
                views.Add(Instantiate(_prefab, transform));

            for (int i = 0; i < _skins.Count; i++)
                views[i].Initialize(_skins[i], views, moneyCounter, SaveSkinsData);
            
            FindSelectedOrBought(views)?.Select();
        }
        
        private void TryLoadModels()
        {
            var items = SaveSystem.Get<List<SkinData>>(GetSaveKey());
            if (items == null) return;
            
            foreach (SkinData item in items)
            {
                Skin skin = _skins.Find(skin => skin.Name == item.Name);
                if (skin == null) continue;
                
                skin.IsBought = item.IsBought;
                skin.IsSelected = item.IsSelected;
            }
        }

        private SkinView<T> FindSelectedOrBought(List<SkinView<T>> views)
        {
            var currentSkin = views.Find(view => view.Model.IsSelected);
            if (currentSkin == null)
                currentSkin = views.Find(view => view.Model.IsBought);
            return currentSkin;
        }

        private void SaveSkinsData()
        {
            var itemsToSave = new List<SkinData>();
            foreach (var skin in _skins) 
                itemsToSave.Add(new SkinData
                {
                    Name = skin.Name,
                    IsBought = skin.IsBought,
                    IsSelected = skin.IsSelected
                });
            SaveSystem.Set(GetSaveKey(), itemsToSave);
        }
        
        protected abstract string GetSaveKey();
    }
}