using UnityEngine;

public class TextExpansion : MonoBehaviour
{
    private RectTransform _rect;
    private float _time;

    void Start() => _rect = GetComponent<RectTransform>(); 

    void Update()
    {
        _time += Time.deltaTime;
        float scaleValue = (Mathf.Sin(_time) + 3) / 4f;
        _rect.localScale = new Vector3(scaleValue, scaleValue, 1);
    }
}
