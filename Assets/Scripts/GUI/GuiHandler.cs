using GUI.ScoreText;
using GUI.Slider;
using GUI.SoundButton;
using GUI.StartText;
using UnityEngine;

namespace GUI
{
    public class GuiHandler : MonoBehaviour
    {
        #region Singleton

        public static GuiHandler Instance { get; private set; }
        private void Awake()
        {
            if (Instance == null) Instance = this;
        }

        #endregion

        [field: SerializeField] public SliderController SliderController { get; set; }
        [field: SerializeField] public ScoreTextController ScoreTextController { get; set; }
        [field: SerializeField] public SoundButtonController SoundButtonController { get; set; }
        [field: SerializeField] public StartTextController StartTextController { get; set; }

        private void Start()
        {
            ScoreTextController.Start();
            SliderController.Start();
            SoundButtonController.Start();
            StartTextController.Start();
        }

        public void OnSoundButtonClick() => SoundButtonController.Switch();

        
        // ________________________________________________________________________________________________
        /*public void OnStartButtonClick()
        {
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(0).gameObject.SetActive(true);
            FindObjectOfType<Axe>().Foo();
        }

        public void OnCancelButtonClick()
        {
            transform.GetChild(1).gameObject.SetActive(true);
            transform.GetChild(0).gameObject.SetActive(false);
            FindObjectOfType<Axe>().Hide();
        }*/
    }
}
