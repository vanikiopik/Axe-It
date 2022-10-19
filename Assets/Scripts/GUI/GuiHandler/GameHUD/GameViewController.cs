using Engines;
using UnityEngine;
using UnityEngine.Events;

namespace GUI.GuiHandler.GameHUD
{
    [System.Serializable]
    public class GameViewController : UiController<GameView>
    {
        [field: SerializeField] public SliderEngine SliderEngine { get; private set; }
        [field: SerializeField] public WinAreaEngine AreaEngine { get; private set; }
        
        public override void Initialize(Gui gui, UnityEvent onUpdate)
        {
            base.Initialize(gui, onUpdate);
            SliderEngine.Initialize(View.Slider, Gui.ScoreCounter);
            AreaEngine.Initialize(View.WinArea, Gui.ScoreCounter);

            View.PauseButton.onClick.AddListener(OnPauseButtonClick);
            Gui.ScoreCounter.OnScoreChanged.AddListener(SetScoreText);
        }

        protected override void Update()
        {
            SliderEngine.Update();
            AreaEngine.Update();
        }

        public void StopSliderAndArea()
        {
            SliderEngine.Stop();
            AreaEngine.Stop();
        }
        
        public void ResetSliderAndArea()
        {
            SliderEngine.Reset();
            AreaEngine.Reset();
        }
        
        public bool IsHandleOverWinArea()
        {
            Vector3[] corners = new Vector3[4];
            View.Handle.GetWorldCorners(corners);
            float centerX = (corners[0].x + corners[3].x) / 2.0f;

            View.WinArea.GetWorldCorners(corners);
            return centerX >= corners[0].x && centerX <= corners[3].x;
        }
        
        private void OnPauseButtonClick()
        {
            Time.timeScale = 0.0f;
            Gui.AxeEngine.enabled = false;
            Gui.PauseMenuViewController.SetActive(true);
        }

        public void SetScoreText(int score, int bestScore)
        {
            View.ScoreText.text = $"Score: {score}";
        }
    }
}