using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextExpansion : MonoBehaviour
{
    RectTransform RectT;
    [SerializeField]
    private float _transformPower = 1.2f;   
    [SerializeField]
    private float _scaleTime = 1.3f;

   /* float Offset;
    [SerializeField]
    private float _time;
    [SerializeField]
    private float _amp;
    [SerializeField]
    private float _freq;
    [SerializeField]
    private float _speed;*/


    void Start()
    {
        RectT = GetComponent<RectTransform>(); 
    }


    void Update()
    {

        /*_time =+ Time.time / _speed;
        Offset =_amp * Mathf.Sin(_time * _freq);
        Offset = Mathf.Clamp01(Offset);
        RectT.localScale = new Vector3(Offset, RectT.localScale.y);*/

        RectT.localScale = new Vector3(Mathf.PingPong(Time.time / _scaleTime, _transformPower), Mathf.PingPong(Time.time / _scaleTime, _transformPower));
    }
}
