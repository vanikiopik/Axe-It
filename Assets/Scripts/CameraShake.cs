using System.Collections;
using GUI.GuiHandler;
using UnityEngine;

[RequireComponent(typeof(Camera))]
public class CameraShake : MonoBehaviour
{
    [SerializeField] private AxeEngine _axe;
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
            Vector3 startPosition = transform.position;
            for (float lerpValue = 0.0f; lerpValue <= 1.0f; lerpValue += Time.deltaTime * _shakingCount / _duration)
            {
                transform.position = Vector3.Lerp(startPosition, targetPosition, lerpValue);
                yield return null;
            }
            transform.position = targetPosition;
        }
    }
}