using UnityEngine;
using UnityEngine.Events;

namespace GUI.GuiHandler.PauseMenuHUD
{
    [System.Serializable]
    public class PauseMenuViewController : UiController<PauseMenuView>
    {
        public override void Initialize(Gui gui, UnityEvent onUpdate)
        {
            base.Initialize(gui, onUpdate);
            View.ExitButton.onClick.AddListener(OnExitButtonClick);
            View.CloseButton.onClick.AddListener(OnCloseButtonClick);
            Gui.ScoreCounter.OnScoreChanged.AddListener(SetScoreText);
        }

        public void SetScoreText(int score, int bestScore)
        {
            View.ScoreText.text = $"Score: {score}\n\nBest Score: {bestScore}";
        }

        private void OnCloseButtonClick()
        {
            Time.timeScale = 1.0f;
            Gui.AxeEngine.enabled = true;
            Gui.PauseMenuViewController.SetActive(false);
        }

        private void OnExitButtonClick()
        {
            Time.timeScale = 1.0f;
            Gui.ScoreCounter.ResetScore();
            Gui.PauseMenuViewController.SetActive(false);
            Gui.GameViewController.SetActive(false);
            Gui.MainMenuViewController.SetActive(true);
            Gui.MoneyPanelViewController.Interactable = true;
        }
    }
}