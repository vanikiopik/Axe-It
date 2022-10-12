using System.Collections;
using Axe;
using UnityEngine;

namespace Wood
{
    [RequireComponent(typeof(MeshCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class Wood : MonoBehaviour
    {
        [SerializeField] private Engines.MoveDirection _throwDirection;
        [Min(0.0f)][SerializeField] private float _throwingForce;
        [Min(0.0f)][SerializeField] private float _throwDelay;

        private WoodRespawner _respawner;

        private void Awake()
        {
            _respawner = new WoodRespawner(transform,
                GetComponent<Rigidbody>(),
                GetComponent<MeshCollider>());
        }

        private void Start() => _respawner.SetTriggeredAndKinematic(true);

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out AxeEngine axeEngine)) return;
            if (axeEngine.State == AxeEngine.AxeState.HitAttack)
                StartCoroutine(Throw());
        }

        private IEnumerator Throw()
        {
            _respawner.SetTriggeredAndKinematic(false);
            _respawner.Rigidbody.AddForce(-transform.right * (_throwingForce * (int)_throwDirection));
            yield return new WaitForSeconds(_throwDelay);
            
            _respawner.Respawn();
        }
    }
}