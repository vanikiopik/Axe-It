using UnityEngine;

namespace GUI.GameOverHUD
{
    [System.Serializable]
    public class GameOverViewController : UiController<GameOverView>
    {
        [SerializeField] private float _reviveTextExpansionSpeed;

        private float _time;
        
        public override void Start(GuiHandler gui)
        {
            base.Start(gui);
            View.ADWatchButton.onClick.AddListener(OnAdWatchButtonClick);
            View.CloseButton.onClick.AddListener(OnCloseButtonClick);
            View.ExitButton.onClick.AddListener(OnCloseButtonClick);
            
            Gui.PauseMenuViewController.View.ExitButton.onClick.AddListener(ResetGameOverMenu);
            ScoreCounter.OnScoreChanged += SetScoreText;
        }

        protected override void Update()
        {
            _time += _reviveTextExpansionSpeed * Time.deltaTime;
            float scaleValue = (Mathf.Sin(_time) + 4) / 6;
            View.ReviveText.localScale = new Vector3(scaleValue, scaleValue, 1);
        }

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