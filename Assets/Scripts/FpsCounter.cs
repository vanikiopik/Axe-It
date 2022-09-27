using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class FpsCounter : MonoBehaviour
{
    private Text _fpsCounter;
    private int _counter;
    private float _time;
    void Start() => _fpsCounter = GetComponent<Text>();

    void Update()
    {
        _counter++;
        _time += Time.deltaTime;
        if (_time >= 1.0f)
        {
            _fpsCounter.text = $"FPS: {_counter}";
            _counter = 0;
            _time = 0.0f;
        }
    }
}