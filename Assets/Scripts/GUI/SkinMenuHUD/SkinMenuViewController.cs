namespace GUI.SkinMenuHUD
{
    [System.Serializable]
    public class SkinMenuViewController : UiController<SkinMenuView>
    {
        public override void Start(GuiHandler gui)
        {
            base.Start(gui);
            View.CloseButton.onClick.AddListener(OnCloseButtonClick);
            View.AxeButton.onClick.AddListener(OnAxesButtonClick);
            View.ThemeButton.onClick.AddListener(OnThemesButtonClick);
        }

        private void OnCloseButtonClick()
        {
            Gui.SkinMenuViewController.SetActive(false);
            Gui.MainMenuViewController.SetActive(true);
            Gui.MoneyPanelViewController.Interactable = true;
        }

        private void OnAxesButtonClick()
        {
            View.ThemeScrollView.SetActive(false);
            View.ThemeOutline.enabled = false;
            View.AxeScrollView.SetActive(true);
            View.AxeOutline.enabled = true;
        }

        private void OnThemesButtonClick()
        {
            View.AxeScrollView.SetActive(false);
            View.AxeOutline.enabled = false;
            View.ThemeScrollView.SetActive(true);
            View.ThemeOutline.enabled = true;
        }
    }
}