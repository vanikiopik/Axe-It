using UnityEngine;

namespace GUI.GameHUD
{
    [System.Serializable]
    public class GameHudController : UiController<GameHudView>
    {
        [SerializeField] private float _sliderSpeed;
        
        public SliderEngine Engine { get; private set; }
        
        public override void Start()
        {
            base.Start();
            Engine = new SliderEngine(_sliderSpeed, View.Slider, View.FillArea, View.Handle);
        }

        protected override void Update() => Engine.Update();
        
        public override void SetActive(bool isActive)
        {
            View.Slider.gameObject.SetActive(isActive);
            View.ScoreText.gameObject.SetActive(isActive);
            View.PauseButton.gameObject.SetActive(isActive);
        }

        public void SetScoreText(string text) => View.ScoreText.text = text;
        
        public void ClearScoreText() => View.ScoreText.text = string.Empty;
    }
}
