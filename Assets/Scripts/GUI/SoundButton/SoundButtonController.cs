namespace GUI.SoundButton
{
    [System.Serializable]
    public class SoundButtonController : UiController<SoundButtonView>
    {
        private bool _soundStatus = true;

        public void Switch()
        {
            _soundStatus = !_soundStatus;
            View.Image.sprite = _soundStatus ? View.SoundOnSprite : View.SoundOffSprite;
        }
    }
}