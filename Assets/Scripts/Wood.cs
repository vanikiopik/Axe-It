using Engines;
using IEnumerator = System.Collections.IEnumerator;
using UnityEngine;

[RequireComponent(typeof(MeshCollider))]
[RequireComponent(typeof(Rigidbody))]
public class Wood : MonoBehaviour
{
    [SerializeField] private MoveDirection _throwDirection;
    [SerializeField] private float _throwingForce;
    [SerializeField] private float _throwDelay;

    private MeshCollider _collider;
    private Rigidbody _rigidbody;
    private Vector3 _startPosition;
    private Quaternion _startRotation;
    
    private void Start()
    {
        _startPosition = transform.position;
        _startRotation = transform.rotation;
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<MeshCollider>();
        _collider.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out AxeEngine axeEngine) && axeEngine.IsWoodAxed)
            StartCoroutine(Throw());
    }

    private IEnumerator Throw()
    {
        _collider.isTrigger = false;
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(-transform.right * (_throwingForce * (int)_throwDirection));
        yield return new WaitForSeconds(_throwDelay);

        _collider.isTrigger = true;
        _rigidbody.isKinematic = true;
        transform.position = _startPosition;
        transform.rotation = _startRotation;
    }
}