namespace GUI.ADMenuHUD
{
    [System.Serializable]
    public class AdMenuViewController : UiController<AdMenuView>
    {
        public override void Start(GuiHandler gui)
        {
            base.Start(gui);
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