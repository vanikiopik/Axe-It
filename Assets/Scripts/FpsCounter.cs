using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FpsCounter : MonoBehaviour
{
    private Text _fpsCounterText;
    private int _counter;
    private float _time;

    private void Start()
    {
        _fpsCounterText = GetComponent<Text>();
        Application.targetFrameRate = 120;
        QualitySettings.vSyncCount = 0;
    }

    private void Update()
    {
        _counter++;
        _time += Time.deltaTime;
        if (_time < 1.0f) return;
        
        _fpsCounterText.text = $"FPS: {_counter}";
        _time = _counter = 0;
    }
}