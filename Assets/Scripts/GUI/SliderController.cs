using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderController : MonoBehaviour
{
    private enum MoveTo { Left = -1, Right = 1 }

    [SerializeField] private float _speed;
    [SerializeField] private RectTransform _fillArea;
    [SerializeField] private RectTransform _handle;

    private Slider _slider;
    private MoveTo _direction;
    private float _size;

    private void Start()
    {
        _slider = GetComponent<Slider>();
        _direction = MoveTo.Right;
    }

    private void Update()
    {
        if (_slider.value <= _slider.minValue) _direction = MoveTo.Right;
        if (_slider.value >= _slider.maxValue) _direction = MoveTo.Left;

        _slider.value += _speed * Time.deltaTime * (int)_direction;
    }

    public void ResetSlider()
    {
        _slider.value = _slider.minValue;
        enabled = true;
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