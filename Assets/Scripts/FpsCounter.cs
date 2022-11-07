using System;
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FpsCounter : MonoBehaviour
{
    private Text _fpsCounterText;
    private int _counter;
    private float _time;

    private int _min = Int32.MaxValue;
    private int _max;
    
    private int _avr;
    private int _seconds;

    private void Start()
    {
        _fpsCounterText = GetComponent<Text>();
        Application.targetFrameRate = 300;
        QualitySettings.vSyncCount = 0;
    }

    private void Update()
    {
        _counter++;
        _time += Time.deltaTime;
        if (_time >= 1.0f)
        {
            _time--;
            _seconds++;
            
            _avr = ((_seconds - 1) * _avr + _counter) / _seconds;
            if (_counter > _max) _max = _counter;
            if (_counter < _min) _min = _counter;

            _fpsCounterText.text = $"FPS: {_counter}\nMax: {_max}\nAvr: {_avr}\nMin: {_min}";
            _counter = 0;
        }
    }
}