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
            ScoreCounter.OnScoreChanged += SetScoreText;
        }

        public void SetScoreText(int score, int bestScore) =>
            View.ScoreText.text = $"Score: {score}\n\nBest Score: {bestScore}";
        
        private void OnCloseButtonClick()
        {
            Time.timeScale = 1.0f;
            Gui.AxeEngine.enabled = true;
            Gui.PauseMenuViewController.SetActive(false);
        }

        private void OnExitButtonClick()
        {
            Time.timeScale = 1.0f;
            ScoreCounter.ResetScore();
            Gui.PauseMenuViewController.SetActive(false);
            Gui.GameViewController.SetActive(false);
            Gui.MainMenuViewController.SetActive(true);
            Gui.MoneyPanelViewController.Interactable = true;
        }
    }
}