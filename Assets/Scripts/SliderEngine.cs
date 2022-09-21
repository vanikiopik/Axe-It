using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SliderEngine
{
    private enum MoveTo { Left = -1, None = 0, Right = 1 }
    private MoveTo _direction = MoveTo.Right;

    private float _sliderSpeed;
    private Slider _slider;
    private RectTransform _fillArea;
    private RectTransform _handle;

    public SliderEngine(float sliderSpeed, Slider slider, RectTransform fillArea, RectTransform handle)
    {
        _sliderSpeed = sliderSpeed;
        _slider = slider;
        _fillArea = fillArea;
        _handle = handle;
    }
    
    public void Update()
    {
        if (_slider.value <= _slider.minValue) _direction = MoveTo.Right;
        if (_slider.value >= _slider.maxValue) _direction = MoveTo.Left;

        _slider.value += _sliderSpeed * Time.deltaTime * (int)_direction;
    }
        
    public void StopSliderMove() => _direction = MoveTo.None;

    public void ResetSlider()
    {
        _slider.value = _slider.minValue;
        _direction = MoveTo.Right;
    }

    public void ResetFillArea()
    {
        RectTransform.Edge edge = (RectTransform.Edge)Random.Range(0, 2);
        float size = 20 * Random.Range(3, 8);
        float inset = Random.Range(0.0f, 100.0f);
        
        _fillArea.SetInsetAndSizeFromParentEdge(edge, inset, size);
    }

    public bool IsHandleOverWinningArea()
    {
        Vector3[] corners = new Vector3[4];
        _handle.GetWorldCorners(corners);
        float centerX = (corners[0].x + corners[3].x) / 2.0f;

        _fillArea.GetWorldCorners(corners);
        return centerX >= corners[0].x && centerX <= corners[3].x;
    }
}
