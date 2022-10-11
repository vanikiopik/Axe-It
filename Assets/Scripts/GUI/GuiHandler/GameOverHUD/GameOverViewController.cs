using UnityEngine.Events;

namespace GUI.GuiHandler.GameOverHUD
{
    [System.Serializable]
    public class GameOverViewController : UiController<GameOverView>
    {
        public override void Initialize(Gui gui, UnityEvent onUpdate)
        {
            base.Initialize(gui, onUpdate);
            View.ADWatchButton.onClick.AddListener(OnAdWatchButtonClick);
            View.CloseButton.onClick.AddListener(OnCloseButtonClick);
            View.ExitButton.onClick.AddListener(OnCloseButtonClick);
            
            Gui.PauseMenuViewController.View.ExitButton.onClick.AddListener(ResetGameOverMenu);
            ScoreCounter.OnScoreChanged.AddListener(SetScoreText);
        }

        protected override void Update() => View.ReviveText.Update();

        public void OnGameOverMenuEnable()
        {
            Gui.AxeEngine.enabled = false;
            Gui.GameViewController.SetActive(false);
            Gui.GameOverViewController.SetActive(true);
        }

        private void OnAdWatchButtonClick()
        {
            // watching advertisement
            View.ADWatchButton.gameObject.SetActive(false);
            View.CloseButton.gameObject.SetActive(false);
            View.ExitButton.gameObject.SetActive(true);
            
            Gui.GameOverViewController.SetActive(false);
            Gui.GameViewController.SetActive(true);
            Gui.AxeEngine.enabled = true;
        }
        
        private void OnCloseButtonClick()
        {
            ScoreCounter.ResetScore();
            ResetGameOverMenu();
            Gui.GameOverViewController.SetActive(false);
            Gui.MainMenuViewController.SetActive(true);
            Gui.MoneyPanelViewController.Interactable = true;
        }

        private void ResetGameOverMenu()
        {
            View.CloseButton.gameObject.SetActive(true);
            View.ADWatchButton.gameObject.SetActive(true);
            View.ExitButton.gameObject.SetActive(false);
        }

        private void SetScoreText(int score, int bestScore) =>
            View.ScoreText.text = $"Score: {score}\n\nBest record: {bestScore}";
    }
}