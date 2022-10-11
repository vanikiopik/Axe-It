using System.Collections.Generic;
using System.Linq;
using Skins;
using UnityEngine;
using UnityEngine.UI;

namespace GUI.GuiHandler.SkinMenuHUD.SkinViews
{
    public abstract class SkinView<T> : UiView where T : Skin
    {
        private List<SkinView<T>> _allViews;
        
        [field: SerializeField] public Image Icon { get; set; }
        [field: SerializeField] public Text Name { get; set; }
        [field: SerializeField] public Text Price { get; set; }
        [field: SerializeField] public Button BuyButton { get; set; }
        [field: SerializeField] public Button SelectButton { get; set; }
        
        [field: Header("Sprites")]
        [field: SerializeField] public Sprite SelectionEnable { get; set; }
        [field: SerializeField] public Sprite SelectionDisable { get; set; }
        
        public T Model { get; private set; }

        public void Initialize(T model, List<SkinView<T>> views)
        {
            Model = model;
            _allViews = views;
            BuyButton.onClick.AddListener(OnBuyButtonClick);
            SelectButton.onClick.AddListener(Select);
            
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
            // decrease money amount
            Model.IsBought = true;
            Select();
        }
    }
}
