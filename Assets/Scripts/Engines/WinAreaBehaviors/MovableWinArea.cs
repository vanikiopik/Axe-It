using UnityEngine;

namespace Engines.WinAreaBehaviors
{
    [System.Serializable]
    public class MovableWinArea : BaseWinAreaBehaviour
    {
        [SerializeField] private float _minSpeed;
        [SerializeField] private float _maxSpeed;
        
        private MoveDirection _direction;
        private float _moveSpeed;

        public override void Update()
        {
            Area.localPosition += new Vector3(_moveSpeed * Time.deltaTime * (int)_direction, 0.0f, 0.0f);

            if (Area.offsetMin.x <= 0.0f) _direction = MoveDirection.Right;
            if (Area.offsetMax.x >= 0.0f) _direction = MoveDirection.Left;
        }

        public override void ResetArea(float newAreaSize)
        {
            base.ResetArea(newAreaSize);
            _moveSpeed = Random.Range(_minSpeed, _maxSpeed);
            _direction = Random.Range(0, 2) == 0 ? MoveDirection.Right : MoveDirection.Left;
        }

        public override void StopMove() => _direction = MoveDirection.None;
    }
}
