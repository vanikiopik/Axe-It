using UnityEngine;

namespace GUI.MainMenuHUD
{
    [System.Serializable]
    public class MainMenuViewController : UiController<MainMenuView>
    {
        private float _time;
        public bool IsSoundOn { get; private set; } = true;

        public override void Start(GuiHandler gui)
        {
            base.Start(gui);
            View.PlayButton.onClick.AddListener(OnPlayButtonClick);
            View.SoundButton.onClick.AddListener(SoundSwitch);
            View.BonusButton.onClick.AddListener(OnBonusButtonClick);
            View.SkinButton.onClick.AddListener(OnSkinMenuButtonClick);
        }

        protected override void Update()
        {
            _time += Time.deltaTime;
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
            Gui.Axe.enabled = true;
            Gui.GameViewController.SetActive(true);
            Gui.GameViewController.Engine.ResetSliderAndArea();
        }

        private void OnSkinMenuButtonClick()
        {
            Gui.MoneyPanelViewController.Interactable = false;
            Gui.MainMenuViewController.SetActive(false);
            Gui.SkinMenuViewController.SetActive(true);
        }
        
        private void OnBonusButtonClick() { /* gives player the bonus */  }
    }
}