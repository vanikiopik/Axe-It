using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReviveTextExpansion : MonoBehaviour
{
    private RectTransform _rect;
    private float _time;

    void Start() => _rect = GetComponent<RectTransform>();

    void Update()
    {
        _time += Time.deltaTime;
        float scaleValue = (Mathf.Sin(_time * 4 * Mathf.PI) + 4) / 6 ;
        _rect.localScale = new Vector3(scaleValue, scaleValue, 1);
    }
}
