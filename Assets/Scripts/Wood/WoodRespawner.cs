using UnityEngine;

namespace Wood
{
    public class WoodRespawner
    {
        private readonly Rigidbody _rigidbody;
        private readonly MeshCollider _collider;

        private readonly Transform _transform;
        private readonly Vector3 _spawnPosition;
        private readonly Quaternion _spawnRotation;

        public Rigidbody Rigidbody => _rigidbody;

        public WoodRespawner(Transform transform, Rigidbody rigidbody, MeshCollider collider)
        {
            _transform = transform;
            _spawnPosition = _transform.position;
            _spawnRotation = _transform.rotation;
            _collider = collider;
            _rigidbody = rigidbody;
        }

        public void SetTriggeredAndKinematic(bool value)
        {
            _collider.isTrigger = value;
            _rigidbody.isKinematic = value;
        }

        public void Respawn()
        {
            SetTriggeredAndKinematic(true);
            _transform.position = _spawnPosition;
            _transform.rotation = _spawnRotation;
        }
    }
}
