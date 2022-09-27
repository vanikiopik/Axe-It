namespace GUI.SkinMenuHUD
{
    [System.Serializable]
    public class SkinMenuViewController : UiController<SkinMenuView>
    {
        public override void Start(GuiHandler gui)
        {
            base.Start(gui);
            View.CloseButton.onClick.AddListener(OnCloseButtonClick);
        }

        private void OnCloseButtonClick()
        {
            Gui.SkinMenuViewController.SetActive(false);
            Gui.MainMenuViewController.SetActive(true);
            Gui.MoneyPanelViewController.Interactable = true;
        }
    }
}