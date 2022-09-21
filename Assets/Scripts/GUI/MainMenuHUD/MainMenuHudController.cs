using UnityEngine;

namespace GUI.MainMenuHUD
{
    [System.Serializable]
    public class MainMenuHudController : UiController<MainMenuHudView>
    {
        private float _time;
        private bool _soundStatus = true;

        public override void SetActive(bool isActive)
        {
            View.StartText.gameObject.SetActive(isActive);
            View.BestRecordText.gameObject.SetActive(isActive);
            View.SoundButtonImage.gameObject.SetActive(isActive);
            View.SkinMenuButton.gameObject.SetActive(isActive);
            View.BonusButton.gameObject.SetActive(isActive);
        }
    
        public void SoundButtonSwitch()
        {
            _soundStatus = !_soundStatus;
            View.SoundButtonImage.sprite = _soundStatus ? View.SoundOnSprite : View.SoundOffSprite;
        }

        protected override void Update()
        {
            _time += Time.deltaTime;
            float scaleValue = (Mathf.Sin(_time) + 3) / 4f;
            View.StartText.rectTransform.localScale = new Vector3(scaleValue, scaleValue, 1);
        }
    }
}
