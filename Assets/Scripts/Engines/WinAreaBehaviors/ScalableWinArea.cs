using UnityEngine;

namespace Engines.WinAreaBehaviors
{
    [System.Serializable]
    public class ScalableWinArea : BaseWinAreaBehaviour
    {
        [SerializeField] private float _minScaleSpeed;
        [SerializeField] private float _maxScaleSpeed;
        [Range(0.0f, 1.0f)][SerializeField] private float _minScaleMultiplier;
        [Range(1.0f, 2.0f)][SerializeField] private float _maxScaleMultiplier;

        private MoveDirection _direction;
        private float _scaleSpeed;
        private float _minScaleValue;
        private float _maxScaleValue;

        public override void Update()
        {
            Area.sizeDelta += new Vector2(_scaleSpeed * Time.deltaTime * (int) _direction, 0.0f);
            
            if (Area.rect.width <= _minScaleValue) _direction = MoveDirection.Right;
            if (Area.rect.width >= _maxScaleValue) _direction = MoveDirection.Left;
            
            if (Area.offsetMin.x <= 0.0f || Area.offsetMax.x >= 0.0f) _direction = MoveDirection.Left;
        }

        public override void ResetArea(float newAreaSize)
        {
            base.ResetArea(newAreaSize);
            _minScaleValue = Area.rect.width * _minScaleMultiplier;
            _maxScaleValue = Area.rect.width * _maxScaleMultiplier;
            _scaleSpeed = Random.Range(_minScaleSpeed, _maxScaleSpeed);
            _direction = Random.Range(0, 2) == 0 ? MoveDirection.Right : MoveDirection.Left;
        }

        public override void StopMove() => _direction = MoveDirection.None;
    }
}
