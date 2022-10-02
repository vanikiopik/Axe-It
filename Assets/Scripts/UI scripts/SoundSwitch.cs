using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SoundSwitch : MonoBehaviour
{
    [SerializeField]
    private bool _soundStatus = true;

    Image image;
    Sprite OFF; 
    Sprite ON;
 
    void Start()
    {
        image = GetComponent<Image>();
        OFF = Resources.Load<Sprite>("UI/SoundOFF");
        ON = Resources.Load<Sprite>("UI/SoundON");
    }

    public void Switch()
    {
        if (_soundStatus)
        {
            gameObject.GetComponent<Image>().sprite = OFF;
            _soundStatus = false;
        }
        else
        { 
            gameObject.GetComponent<Image>().sprite = ON;
            _soundStatus=true;
        }
    }


}
