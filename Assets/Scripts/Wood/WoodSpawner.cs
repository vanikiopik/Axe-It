using UnityEngine;

namespace Wood
{
    public class WoodSpawner
    {
        private readonly Vector3 _spawnPosition;
        private readonly Quaternion _spawnRotation;

        private readonly Transform _transform;
        private readonly MeshCollider _collider;

        public Rigidbody Rigidbody { get; }

        public WoodSpawner(Transform transform, Rigidbody rigidbody, MeshCollider collider)
        {
            Rigidbody = rigidbody;
            _collider = collider;
            _transform = transform;
            _spawnPosition = _transform.position;
            _spawnRotation = _transform.rotation;
        }

        public void SetTriggeredAndKinematic(bool value)
        {
            _collider.isTrigger = value;
            Rigidbody.isKinematic = value;
        }
        
        public void Respawn()
        {
            SetTriggeredAndKinematic(true);
            _transform.position = _spawnPosition;
            _transform.rotation = _spawnRotation;
        }
    }
}