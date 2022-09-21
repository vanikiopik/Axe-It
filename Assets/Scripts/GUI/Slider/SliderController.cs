using UnityEngine;

namespace GUI.Slider
{
    [System.Serializable]
    public class SliderController : UiController<SliderView>
    {
        private enum MoveTo { Left = -1, None = 0, Right = 1 }

        [SerializeField] private float _speed;

        private MoveTo _direction = MoveTo.Right;

        protected override void Update()
        {
            if (View.Slider.value <= View.Slider.minValue) _direction = MoveTo.Right;
            if (View.Slider.value >= View.Slider.maxValue) _direction = MoveTo.Left;

            View.Slider.value += _speed * Time.deltaTime * (int)_direction;
        }

        public void StopSliderMove() => _direction = MoveTo.None;

        public void ResetSlider()
        {
            View.Slider.value = View.Slider.minValue;
            _direction = MoveTo.Right;
        }

        public void ResetFillArea()
        {
            RectTransform.Edge edge = (RectTransform.Edge)Random.Range(0, 2);
            float size = 20 * Random.Range(3, 8);
            float inset = Random.Range(0.0f, 100.0f);
        
            View.FillArea.SetInsetAndSizeFromParentEdge(edge, inset, size);
        }

        public bool IsHandleOverWinningArea()
        {
            Vector3[] corners = new Vector3[4];
            View.Handle.GetWorldCorners(corners);
            float centerX = (corners[0].x + corners[3].x) / 2.0f;

            View.FillArea.GetWorldCorners(corners);
            return centerX >= corners[0].x && centerX <= corners[3].x;
        }
    }
}