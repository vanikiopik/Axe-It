using UnityEngine;
using UnityEngine.UI;

public class SoundSwitcher : MonoBehaviour
{
    private Image _image;
    private Sprite _soundOffSprite;
    private Sprite _soundOnSprite;
    private bool _soundStatus;

    private void Start()
    {
        _image = GetComponent<Image>();
        _soundOffSprite = Resources.Load<Sprite>("UI/SoundOFF");
        _soundOnSprite = Resources.Load<Sprite>("UI/SoundON");
        _soundStatus = true;
    }

    public void Switch()
    {
        if (_soundStatus)
        {
            _image.sprite = _soundOffSprite;
            _soundStatus = false;
        }
        else
        { 
            _image.sprite = _soundOnSprite;
            _soundStatus = true;
        }
    }
}