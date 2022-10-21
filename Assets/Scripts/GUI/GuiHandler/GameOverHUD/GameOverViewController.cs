using Ads;
using UnityEngine;
using UnityEngine.Events;

namespace GUI.GuiHandler.GameOverHUD
{
    [System.Serializable]
    public class GameOverViewController : UiController<GameOverView>
    {
        [SerializeField] private RewardedAd _continueAd;
        [SerializeField] private InterstitialAd _adBeforeGameOver;

        [SerializeField] private int _gameOversAmountToAd;

        private int _gameOversAmount;
        
        public override void Initialize(Gui gui, UnityEvent onUpdate)
        {
            base.Initialize(gui, onUpdate);
            _adBeforeGameOver.Initialize();
            _continueAd.Initialize(ContinueGameReward, View.ADWatchButton.onClick);

            View.CloseButton.onClick.AddListener(OnCloseButtonClick);
            View.ExitButton.onClick.AddListener(OnCloseButtonClick);
            
            Gui.PauseMenuViewController.View.ExitButton.onClick.AddListener(ResetGameOverMenu);
            Gui.ScoreCounter.OnScoreChanged.AddListener(SetScoreText);
        }

        protected override void Update() => View.ReviveText.Update();

        public void OnGameOverMenuEnable()
        {
            Gui.AxeEngine.enabled = false;
            Gui.GameViewController.SetActive(false);
            Gui.GameOverViewController.SetActive(true);
        }

        private void ContinueGameReward()
        {
            View.ADWatchButton.gameObject.SetActive(false);
            View.CloseButton.gameObject.SetActive(false);
            View.ExitButton.gameObject.SetActive(true);
             
            Gui.GameOverViewController.SetActive(false);
            Gui.GameViewController.SetActive(true);
            Gui.AxeEngine.enabled = true;
        }
        
        private void OnCloseButtonClick()
        {
            Gui.ScoreCounter.ResetScore();
            ResetGameOverMenu();
            Gui.GameOverViewController.SetActive(false);
            Gui.MainMenuViewController.SetActive(true);
            Gui.MoneyPanelViewController.Interactable = true;
            
            if (++_gameOversAmount % _gameOversAmountToAd == 0) 
                _adBeforeGameOver.ShowAd();
        }

        private void ResetGameOverMenu()
        {
            View.CloseButton.gameObject.SetActive(true);
            View.ADWatchButton.gameObject.SetActive(true);
            View.ExitButton.gameObject.SetActive(false);
        }

        private void SetScoreText(int score, int bestScore)
        {
            View.ScoreText.text = $"Score: {score}\n\nBest record: {bestScore}";
        }
    }
}