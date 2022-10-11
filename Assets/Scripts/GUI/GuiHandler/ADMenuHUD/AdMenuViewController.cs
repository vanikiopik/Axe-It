using UnityEngine.Events;

namespace GUI.GuiHandler.ADMenuHUD
{
    [System.Serializable]
    public class AdMenuViewController : UiController<AdMenuView>
    {
        public override void Initialize(Gui gui, UnityEvent onUpdate)
        {
            base.Initialize(gui, onUpdate);
            View.CloseButton.onClick.AddListener(OnCloseButtonClick);
            View.AdWatchButton.onClick.AddListener(OnWatchButtonClick);
        }

        private void OnCloseButtonClick()
        {
            Gui.AdMenuViewController.SetActive(false);
            Gui.MainMenuViewController.SetActive(true);
        }

        private void OnWatchButtonClick() { /* watch advertisement */ }
    }
}