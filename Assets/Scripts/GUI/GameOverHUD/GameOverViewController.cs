namespace GUI.GameOverHUD
{
    [System.Serializable]
    public class GameOverViewController : UiController<GameOverView>
    {
        public override void Start(GuiHandler gui)
        {
            base.Start(gui);
            View.ADWatchButton.onClick.AddListener(OnAdWatchButtonClick);
            View.PayButton.onClick.AddListener(OnPayButtonClick);
            View.CloseButton.onClick.AddListener(OnCloseButtonClick);
            View.ExitButton.onClick.AddListener(OnCloseButtonClick);
            
            Gui.PauseMenuViewController.View.ExitButton.onClick.AddListener(ResetGameOverMenu);
        }

        public void OnGameOverMenuEnable()
        {
            Gui.Axe.enabled = false;
            Gui.GameViewController.SetActive(false);
            Gui.GameOverViewController.SetActive(true);
        }

        private void OnAdWatchButtonClick()
        {
            // watching advertisement
            View.ADWatchButton.gameObject.SetActive(false);
            View.PayButton.gameObject.SetActive(true);
            
            Gui.GameOverViewController.SetActive(false);
            Gui.GameViewController.SetActive(true);
            Gui.Axe.enabled = true;
        }
        
        private void OnPayButtonClick()
        {
            // paying money to continue the game
            View.PayButton.gameObject.SetActive(false);
            View.CloseButton.gameObject.SetActive(false);
            View.ExitButton.gameObject.SetActive(true);
            
            Gui.GameOverViewController.SetActive(false);
            Gui.GameViewController.SetActive(true);
            Gui.Axe.enabled = true;
        }
        
        private void OnCloseButtonClick()
        {
            ResetGameOverMenu();
            Gui.GameOverViewController.SetActive(false);
            Gui.MainMenuViewController.SetActive(true);
            Gui.MoneyPanelViewController.Interactable = true;
        }

        private void ResetGameOverMenu()
        {
            View.CloseButton.gameObject.SetActive(true);
            View.ADWatchButton.gameObject.SetActive(true);
            View.PayButton.gameObject.SetActive(false);
            View.ExitButton.gameObject.SetActive(false);
        }
    }
}