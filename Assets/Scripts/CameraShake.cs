using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [SerializeField] private float _sizeDelta;
    [SerializeField] private int _shakingCount;
    [SerializeField] private float _duration;
    public void Shake()
    {
        Vector3 startPosition = transform.position;
        List<Vector3> path = new List<Vector3>(_shakingCount + 1) {startPosition};
        
        for (int i = 0; i < _shakingCount; ++i)
            path.Insert(0,  startPosition + new Vector3(_sizeDelta * (i % 2 == 0 ? -1 : 1), 0, 0));
            
        transform.DOPath(path.ToArray(), _duration);
    }
}
