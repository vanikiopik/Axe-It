using Engines.WinAreaBehaviors;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Engines
{
    [System.Serializable]
    public class WinAreaEngine
    {
        [SerializeField] private AnimationCurve _areaSizeDecrease;
        [SerializeField] private float _minMaxOffset;

        [Space][Header("Area Behaviours")]
        private DefaultWinArea _defaultWinArea = new();
        [SerializeField] private MovableWinArea _movableWinArea;
        [SerializeField] private ScalableWinArea _scalableWinArea;

        private BaseWinAreaBehaviour _currentBehaviour;
        
        public void Initialize(RectTransform winArea)
        {
            _defaultWinArea.Initialize(winArea);
            _movableWinArea.Initialize(winArea);
            _scalableWinArea.Initialize(winArea);
            Reset();
        }
        
        public void Reset()
        {
            switch (ScoreCounter.Score / _areaSizeDecrease[_areaSizeDecrease.length - 1].time)
            {
                case >= 0.0f and <= 0.3f:
                    _currentBehaviour = _defaultWinArea;
                    break;
                case > 0.3f and <= 0.5f:
                    _currentBehaviour = Random.Range(0, 3) switch
                    {
                        0 => _defaultWinArea,
                        1 => _movableWinArea,
                        _ => _scalableWinArea
                    };
                    break;
                case > 0.5f:
                    _currentBehaviour = Random.Range(0, 2) switch
                    {
                        0 => _movableWinArea,
                        _ => _scalableWinArea
                    };
                    break;
            }

            float maxSize = _areaSizeDecrease.Evaluate(ScoreCounter.Score) + _minMaxOffset / 2.0f;
            _currentBehaviour.ResetArea(Random.Range(maxSize - _minMaxOffset, maxSize));
        }
        
        public void Update() => _currentBehaviour.Update();
        
        public void Stop() => _currentBehaviour.StopMove();
    }
}
