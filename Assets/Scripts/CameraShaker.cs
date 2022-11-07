using System.Collections;
using GUI.GuiHandler;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraShaker : MonoBehaviour
{
    [SerializeField] private Axe.AxeEngine _axe;
    [Min(0.0f)][SerializeField] private float _deltaDistanceX;
    [Min(2.0f)][SerializeField] private int _shakingCount;
    [Min(0.0f)][SerializeField] private float _duration;

    private Vector3[] _path;
    private Transform _transform;

    private void Start()
    {
        _transform = transform;
        _path = new Vector3[_shakingCount + 1];
        _path[_shakingCount] = _transform.position;
        _path[_shakingCount - 1] = _path[_shakingCount] - new Vector3(_deltaDistanceX, 0, 0);
        _path[_shakingCount - 2] = _path[_shakingCount] + new Vector3(_deltaDistanceX, 0, 0);
        
        for (int i = _shakingCount - 3; i >= 0; --i) _path[i] = _path[i + 2];
    }

    private void OnEnable() => _axe.CameraShaking += Shake;
    private void OnDisable() => _axe.CameraShaking -= Shake;

    private void Shake()
    {
        StartCoroutine(Shaking());
        if (Gui.Instance.MainMenuViewController.IsSoundOn) Handheld.Vibrate();
    }

    private IEnumerator Shaking()
    {
        foreach (Vector3 targetPosition in _path)
        {
            Vector3 startPosition = _transform.position;
            for (float value = 0.0f; value <= 1.0f; value += Time.deltaTime * _shakingCount / _duration)
            {
                _transform.position = Vector3.Lerp(startPosition, targetPosition, value);
                yield return null;
            }
            _transform.position = targetPosition;
        }
    }
}