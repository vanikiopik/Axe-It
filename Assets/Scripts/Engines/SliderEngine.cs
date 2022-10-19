using UnityEngine;
using UnityEngine.UI;

namespace Engines
{
    [System.Serializable]
    public class SliderEngine
    {
        [SerializeField] private AnimationCurve _speedIncrease;
    
        private MoveDirection _direction;
        private Slider _slider;
        private float _sliderSpeed;
        private ScoreCounter _scoreCounter;

        public void Initialize(Slider slider, ScoreCounter scoreCounter)
        {
            _direction = MoveDirection.None;
            _slider = slider;
            _sliderSpeed = _speedIncrease[0].value;
            _scoreCounter = scoreCounter;
        }

        public void Update()
        {
            _slider.value += _sliderSpeed * Time.deltaTime * (int) _direction;
        
            if (_slider.value <= _slider.minValue) _direction = MoveDirection.Right;
            if (_slider.value >= _slider.maxValue) _direction = MoveDirection.Left;
        }

        public void Reset()
        {
            _direction = MoveDirection.Right;
            _slider.value = _slider.minValue;
            _sliderSpeed = _speedIncrease.Evaluate(_scoreCounter.Score);
        }

        public void Stop() => _direction = MoveDirection.None;
    }
}