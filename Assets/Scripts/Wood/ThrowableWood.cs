using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Events;
using Axe;
using Engines;

namespace Wood
{
    [RequireComponent(typeof(MeshRenderer))]
    [RequireComponent(typeof(MeshCollider))]
    [RequireComponent(typeof(Rigidbody))]
    public class ThrowableWood : MonoBehaviour
    {
        private readonly UnityEvent _onResetGraphics = new();
        private WoodSpawner _spawner;
        private WoodsBase _woods;
        
        private MoveDirection _throwDirection;

        public void Initialize(WoodsBase woods, MoveDirection throwDirection)
        {
            _woods = woods;
            _throwDirection = throwDirection;
            _onResetGraphics.AddListener(woods.ResetMaterials);
        }

        private void Awake()
        {
            _spawner = new WoodSpawner(transform,
                GetComponent<Rigidbody>(),
                GetComponent<MeshCollider>());
        }

        private void Start() => _spawner.SetTriggeredAndKinematic(true);

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent(out AxeEngine axeEngine)) return;
            if (axeEngine.State != AxeEngine.AxeState.HitAttack) return;

            StartCoroutine(Throw(axeEngine.GoldWoodAxed));
        }

        private IEnumerator Throw(Action goldWoodAxed)
        {
            _spawner.SetTriggeredAndKinematic(false);
            _spawner.Rigidbody.AddForce(-transform.right * (_woods.ThrowingForce * (int)_throwDirection));
            yield return new WaitForSeconds(_woods.ThrowDelay);
            
            _spawner.Respawn();
            
            if (_throwDirection == MoveDirection.Right) yield break;
            
            if (_woods.IsGold) goldWoodAxed?.Invoke();
            _onResetGraphics?.Invoke();
        }
    }
}