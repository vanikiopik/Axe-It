using UnityEngine.Events;

namespace GUI.GuiHandler.MainMenuHUD
{
    [System.Serializable]
    public class MainMenuViewController : UiController<MainMenuView>
    {
        public bool IsSoundOn { get; private set; } = true;

        public override void Initialize(Gui gui, UnityEvent onUpdate)
        {
            base.Initialize(gui, onUpdate);
            View.PlayButton.onClick.AddListener(OnPlayButtonClick);
            View.SoundButton.onClick.AddListener(SoundSwitch);
            View.BonusButton.onClick.AddListener(OnBonusButtonClick);
            View.SkinButton.onClick.AddListener(OnSkinMenuButtonClick);
            ScoreCounter.OnScoreChanged.AddListener(SetBestRecordText);
        }

        protected override void Update() => View.StartText.Update();

        private void SoundSwitch()
        {
            IsSoundOn = !IsSoundOn;
            View.SoundButton.image.sprite = IsSoundOn ? View.SoundOnSprite : View.SoundOffSprite;
        }
        
        private void OnPlayButtonClick()
        {
            Gui.MoneyPanelViewController.Interactable = false;
            Gui.MainMenuViewController.SetActive(false);
            Gui.AxeEngine.enabled = true;
            Gui.GameViewController.SetActive(true);
            Gui.GameViewController.ResetSliderAndArea();
        }

        private void OnSkinMenuButtonClick()
        {
            Gui.MoneyPanelViewController.Interactable = false;
            Gui.MainMenuViewController.SetActive(false);
            Gui.SkinMenuViewController.SetActive(true);
            Gui.SkinMenuViewController.View.AxeButton.onClick?.Invoke();
        }
        
        private void OnBonusButtonClick() { /* gives player the bonus */  }

        private void SetBestRecordText(int s, int bestScore) =>
            View.BestRecordText.text = $"Best record:\n{bestScore}";
    }
}