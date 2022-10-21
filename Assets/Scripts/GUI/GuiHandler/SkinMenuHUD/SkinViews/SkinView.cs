using System.Collections.Generic;
using System.Linq;
using Skins;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

namespace GUI.GuiHandler.SkinMenuHUD.SkinViews
{
    public abstract class SkinView<T> : UiView where T : Skin
    {
        private List<SkinView<T>> _allViews;
        private MoneyCounter _moneyCounter;
        
        [field: SerializeField] public Image Icon { get; private set; }
        [field: SerializeField] public Text Name { get; private set; }
        [field: SerializeField] public Text Price { get; private set; }
        [field: SerializeField] public Button BuyButton { get; private set; }
        [field: SerializeField] public Button SelectButton { get; private set; }
        
        [field: Header("Sprites")]
        [field: SerializeField] public Sprite SelectionEnable { get; private set; }
        [field: SerializeField] public Sprite SelectionDisable { get; private set; }
        
        public T Model { get; private set; }

        public void Initialize(T model, List<SkinView<T>> views, MoneyCounter moneyCounter, UnityAction saveSkinsData)
        {
            Model = model;
            _allViews = views;
            _moneyCounter = moneyCounter;
            BuyButton.onClick.AddListener(OnBuyButtonClick);
            BuyButton.onClick.AddListener(saveSkinsData);
            SelectButton.onClick.AddListener(Select);
            SelectButton.onClick.AddListener(saveSkinsData);

            UpdateView();
        }

        private void UpdateView()
        {
            Icon.sprite = Model.Icon;
            Name.text = Model.Name;
            Price.text = Model.Price.ToString();
            BuyButton.gameObject.SetActive(!Model.IsBought);
            SelectButton.gameObject.SetActive(Model.IsBought);
            SelectButton.image.sprite = Model.IsSelected ? SelectionEnable : SelectionDisable;
        }

        public void Select()
        {
            foreach (SkinView<T> view in _allViews.Where(view => view.Model.IsBought))
            {
                view.Model.IsSelected = false;
                view.SelectButton.image.sprite = SelectionDisable;
            }
            
            Model.IsSelected = true;
            Model.LoadGraphic(_allViews);
            UpdateView();
        }

        private void OnBuyButtonClick()
        {
            if (!_moneyCounter.TryTakeCoins(Model.Price)) return;
            Model.IsBought = true;
            Select();
        }
    }
}