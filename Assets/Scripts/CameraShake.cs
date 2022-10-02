using DG.Tweening;
using GUI;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraShake : MonoBehaviour
{
    [SerializeField] private float _deltaDistance;
    [SerializeField] private int _shakingCount;
    [SerializeField] private float _duration;

    private Vector3[] _path;

    private void Start()
    {
        _path = new Vector3[_shakingCount + 1];
        _path[_shakingCount] = transform.position;
        _path[_shakingCount - 1] = _path[_shakingCount] - new Vector3(_deltaDistance, 0, 0);
        _path[_shakingCount - 2] = _path[_shakingCount] + new Vector3(_deltaDistance, 0, 0);
        
        for (int i = _shakingCount - 3; i >= 0; --i) _path[i] = _path[i + 2];
    }

    public void Shake()
    {       
        transform.DOPath(_path, _duration);
        if (GuiHandler.Instance.MainMenuViewController.IsSoundOn) Handheld.Vibrate();
    }
}