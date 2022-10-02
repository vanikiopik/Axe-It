using IEnumerator = System.Collections.IEnumerator;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Wood : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Vector3 _startPosition;
    private Quaternion _startRotation;
    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _startPosition = transform.position;
        _startRotation = transform.rotation;
    }

    public IEnumerator Throw(float force, float delay)
    {
        _rigidbody.isKinematic = false;
        _rigidbody.AddForce(transform.right * force);
        yield return new WaitForSeconds(delay);
        
        _rigidbody.isKinematic = true;
        transform.position = _startPosition;
        transform.rotation = _startRotation;
    }
}