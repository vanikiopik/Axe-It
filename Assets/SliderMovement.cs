using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class SliderMovement : MonoBehaviour
{
    enum MoveTo { Left = -1, Right = 1 }
    
    [SerializeField] private float _speed;

    private Slider _slider;
    private MoveTo _direction;
    
    void Start()
    {
        _slider = GetComponent<Slider>();
        _direction = MoveTo.Right;
    }

    void Update()
    {
        if (_slider.value == _slider.maxValue) _direction = MoveTo.Left;
        if (_slider.value == _slider.minValue) _direction = MoveTo.Right;

        _slider.value += _speed * Time.deltaTime * (int)_direction;
    }
}
