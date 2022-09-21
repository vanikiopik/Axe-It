using UnityEngine;
using UnityEngine.UI;

namespace GUI.SoundButton
{
    [RequireComponent(typeof(Image))]
    public class SoundButtonView : UiView
    {
        public Image Image { get; private set; }
        public Sprite SoundOffSprite { get; private set; }
        public Sprite SoundOnSprite { get; private set; }

        private void Start()
        {
            Image = GetComponent<Image>();
            SoundOffSprite = Resources.Load<Sprite>("UI/SoundOFF");
            SoundOnSprite = Resources.Load<Sprite>("UI/SoundON");
        }
    }
}
