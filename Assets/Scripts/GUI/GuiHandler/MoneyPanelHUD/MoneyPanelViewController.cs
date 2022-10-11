using UnityEngine.Events;

namespace GUI.GuiHandler.MoneyPanelHUD
{
    [System.Serializable]
    public class MoneyPanelViewController : UiController<MoneyPanelView>
    {
        public bool Interactable
        {
            get => View.AddMoneyButton.interactable;
            set => View.AddMoneyButton.interactable = value;
        }

        public override void Initialize(Gui gui, UnityEvent onUpdate)
        {
            base.Initialize(gui, onUpdate);
            View.AddMoneyButton.onClick.AddListener(OnAddMoneyButtonClick);
        }

        public void SetMoneyText(int amount) => View.MoneyText.text = amount.ToString();
        
        private void OnAddMoneyButtonClick()
        {
            Gui.MainMenuViewController.SetActive(false);
            Gui.AdMenuViewController.SetActive(true);
        }
    }
}