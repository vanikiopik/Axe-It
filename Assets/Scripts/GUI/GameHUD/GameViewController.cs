using UnityEngine;

namespace GUI.GameHUD
{
    [System.Serializable]
    public class GameViewController : UiController<GameView>
    {
        [field: SerializeField] public SliderEngine Engine { get; private set; }
        
        public override void Start(GuiHandler gui)
        {
            base.Start(gui);
            Engine.Start(View);
            View.PauseButton.onClick.AddListener(OnPauseButtonClick);
        }

        protected override void Update() => Engine.Update();

        public void SetScoreText(int score) => View.ScoreText.text = $"Score: {score}";
        
        public void ClearScoreText() => View.ScoreText.text = string.Empty;
        
        private void OnPauseButtonClick()
        {
            Time.timeScale = 0.0f;
            Gui.Axe.enabled = false;
            Gui.PauseMenuViewController.SetActive(true);
        }
    }
}