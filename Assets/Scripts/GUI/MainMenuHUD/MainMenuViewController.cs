using UnityEngine;

namespace GUI.MainMenuHUD
{
    [System.Serializable]
    public class MainMenuViewController : UiController<MainMenuView>
    {
        [SerializeField] private float _startTextSpeed;
        
        private float _time;
        
        public bool IsSoundOn { get; private set; } = true;

        public override void Start(GuiHandler gui)
        {
            base.Start(gui);
            View.PlayButton.onClick.AddListener(OnPlayButtonClick);
            View.SoundButton.onClick.AddListener(SoundSwitch);
            View.BonusButton.onClick.AddListener(OnBonusButtonClick);
            View.SkinButton.onClick.AddListener(OnSkinMenuButtonClick);
            ScoreCounter.OnScoreChanged += SetBestRecordText;
        }

        protected override void Update()
        {
            _time += _startTextSpeed * Time.deltaTime;
            float scaleValue = (Mathf.Sin(_time) + 3.0f) / 4.0f;
            View.StartText.rectTransform.localScale = new Vector3(scaleValue, scaleValue, 1.0f);
        }

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