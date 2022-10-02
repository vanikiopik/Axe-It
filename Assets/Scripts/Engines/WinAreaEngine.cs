using Engines.WinAreaBehaviors;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Engines
{
    [System.Serializable]
    public class WinAreaEngine
    {
        [SerializeField] private AnimationCurve _areaSizeDecrease;
        [SerializeField] private float _minAndMaxSizeOffset;

        [Space][Header("Area Behaviours")]
        private DefaultWinArea _defaultWinArea = new();
        [SerializeField] private MovableWinArea _movableWinArea;
        [SerializeField] private ScalableWinArea _scalableWinArea;

        private BaseWinAreaBehaviour _currentWinAreaBehaviour;
        
        public void Start(RectTransform winArea)
        {
            _defaultWinArea.Start(winArea);
            _movableWinArea.Start(winArea);
            _scalableWinArea.Start(winArea);
            Reset();
        }
        
        public void Reset()
        {
            if (ScoreCounter.Score <= _areaSizeDecrease[_areaSizeDecrease.length - 1].time * 0.3f)
            {
                _currentWinAreaBehaviour = _defaultWinArea;
            }
            else if (ScoreCounter.Score <= _areaSizeDecrease[_areaSizeDecrease.length - 1].time * 0.6f)
            {
                switch (Random.Range(0, 3))
                {
                    case 0: _currentWinAreaBehaviour = _defaultWinArea; break;
                    case 1: _currentWinAreaBehaviour = _movableWinArea; break;
                    default: _currentWinAreaBehaviour = _scalableWinArea; break;
                }
            }
            else
            {
                switch (Random.Range(0, 2))
                {
                    case 0: _currentWinAreaBehaviour = _movableWinArea; break;
                    default: _currentWinAreaBehaviour = _scalableWinArea; break;
                }
            }

            float maxSize = _areaSizeDecrease.Evaluate(ScoreCounter.Score) + _minAndMaxSizeOffset / 2.0f;
            _currentWinAreaBehaviour.ResetArea(Random.Range(maxSize - _minAndMaxSizeOffset, maxSize));
        }
        
        public void Update() => _currentWinAreaBehaviour.Update();
        
        public void Stop() => _currentWinAreaBehaviour.StopMove();
    }
}
