using UnityEngine;

namespace GUI.PauseMenuHUD
{
    [System.Serializable]
    public class PauseMenuViewController : UiController<PauseMenuView>
    {
        public override void Start(GuiHandler gui)
        {
            base.Start(gui);
            View.ExitButton.onClick.AddListener(OnExitButtonClick);
            View.CloseButton.onClick.AddListener(OnCloseButtonClick);
        }

        public void SetScoreInfoText(int score, int bestScore) =>
            View.ScoreInfoText.text = $"Score: {score}\n\nBest Score: {bestScore}";
        
        private void OnCloseButtonClick()
        {
            Time.timeScale = 1.0f;
            Gui.Axe.enabled = true;
            Gui.PauseMenuViewController.SetActive(false);
        }

        private void OnExitButtonClick()
        {
            Time.timeScale = 1.0f;
            Gui.PauseMenuViewController.SetActive(false);
            Gui.GameViewController.SetActive(false);
            Gui.MainMenuViewController.SetActive(true);
            Gui.MoneyPanelViewController.Interactable = true;
        }
    }
}