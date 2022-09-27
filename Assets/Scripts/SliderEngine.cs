using GUI.GameHUD;
using UnityEngine;
using Random = UnityEngine.Random;

[System.Serializable]
public class SliderEngine
{
    private enum MoveTo { Left = -1, None = 0, Right = 1 }
    private MoveTo _direction = MoveTo.None;
    
    [SerializeField] private AnimationCurve _speedIncreaseCurve;
    [SerializeField] private float _speedIncreaseValue;
    
    private GameView _view;
    private float _sliderSpeed;
    private float _iteration;

    public void Start(GameView view)
    {
        _view = view;
        _sliderSpeed = _speedIncreaseCurve[0].value;
    }

    public void Update()
    {
        _view.Slider.value += _sliderSpeed * Time.deltaTime * (int) _direction;
        
        if (_view.Slider.value <= _view.Slider.minValue) _direction = MoveTo.Right;
        if (_view.Slider.value >= _view.Slider.maxValue) _direction = MoveTo.Left;
    }

    public void StopSliderMove() => _direction = MoveTo.None;

    public void IncreaseSliderSpeed() => _sliderSpeed = _speedIncreaseCurve.Evaluate(_iteration += _speedIncreaseValue);

    public void ResetSliderAndArea()
    {
        _direction = MoveTo.Right;
        _view.Slider.value = _view.Slider.minValue;

        RectTransform.Edge edge = (RectTransform.Edge) Random.Range(0, 2);
        float size = 20 * Random.Range(3, 8);
        float inset = Random.Range(0.0f, 150.0f);
        _view.WinArea.SetInsetAndSizeFromParentEdge(edge, inset, size);
    }

    public bool IsHandleOverWinningArea()
    {
        Vector3[] corners = new Vector3[4];
        _view.Handle.GetWorldCorners(corners);
        float centerX = (corners[0].x + corners[3].x) / 2.0f;

        _view.WinArea.GetWorldCorners(corners);
        return centerX >= corners[0].x && centerX <= corners[3].x;
    }
}