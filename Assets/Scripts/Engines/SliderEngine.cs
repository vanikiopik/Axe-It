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

        public void Initialize(Slider slider)
        {
            _direction = MoveDirection.None;
            _slider = slider;
            _sliderSpeed = _speedIncrease[0].value;
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
            _sliderSpeed = _speedIncrease.Evaluate(ScoreCounter.Score);
        }

        public void Stop() => _direction = MoveDirection.None;
    }
}