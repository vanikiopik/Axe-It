using UnityEngine;
using UnityEngine.Events;

namespace GUI.GuiHandler.MainMenuHUD
{
    [System.Serializable]
    public class MainMenuViewController : UiController<MainMenuView>
    {
        [Min(0)][SerializeField] private int _bonusReward;
        
        [Tooltip("Cooldown of getting bonus in seconds")]
        [Min(0)][SerializeField] private float _bonusCooldown;
        
        private const string IsSoundOnSaveKey = "IsSoundOn";
        private Timer _timer;
        
        public bool IsSoundOn { get; private set; }

        public override void Initialize(Gui gui, UnityEvent onUpdate)
        {
            base.Initialize(gui, onUpdate);
            View.PlayButton.onClick.AddListener(OnPlayButtonClick);
            View.SoundButton.onClick.AddListener(SoundSwitch);
            View.BonusButton.onClick.AddListener(OnBonusButtonClick);
            View.SkinButton.onClick.AddListener(OnSkinMenuButtonClick);
            Gui.ScoreCounter.OnScoreChanged.AddListener(SetBestRecordText);

            IsSoundOn = SaveSystem.Get<bool>(IsSoundOnSaveKey);
            UpdateSoundView();

            _timer = new Timer("NextBonusTime", _bonusCooldown);
        }

        protected override void Update()
        {
            View.StartText.Update();
            View.BonusCooldownText.text = _timer.IsEventCanBe ? "Get it!"
                : $"{_timer.SpanHours}:{_timer.SpanMinutes}:{_timer.SpanSeconds}";
        }

        private void UpdateSoundView()
        {
            View.SoundButton.image.sprite = IsSoundOn
                ? View.SoundOnSprite
                : View.SoundOffSprite;
        }
        
        private void OnPlayButtonClick()
        {
            Gui.MoneyPanelViewController.Interactable = false;
            Gui.MainMenuViewController.SetActive(false);
            Gui.AxeEngine.enabled = true;
            Gui.GameViewController.SetActive(true);
            Gui.GameViewController.ResetSliderAndArea();
        }

        private void SoundSwitch()
        {
            IsSoundOn = !IsSoundOn;
            SaveSystem.Set(IsSoundOnSaveKey, IsSoundOn);
            UpdateSoundView();
        }

        private void OnSkinMenuButtonClick()
        {
            Gui.MoneyPanelViewController.Interactable = false;
            Gui.MainMenuViewController.SetActive(false);
            Gui.SkinMenuViewController.SetActive(true);
            Gui.SkinMenuViewController.View.AxeButton.onClick?.Invoke();
        }

        private void OnBonusButtonClick()
        {
            if (!_timer.IsEventCanBe) return;
            
            Gui.MoneyCounter.AddCoins(_bonusReward);
            _timer.Reset();
        }

        private void SetBestRecordText(int score, int bestScore)
        {
            View.BestRecordText.text = $"Best record:\n{bestScore}";
        }
    }
}