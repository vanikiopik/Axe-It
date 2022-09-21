using GUI.GameHUD;
using GUI.MainMenuHUD;
using GUI.MoneyTableHUD;
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
        
        [field: SerializeField] public MainMenuHudController MainMenuHudController { get; set; }
        [field: SerializeField] public GameHudController GameHudController { get; set; }
        [field: SerializeField] public MoneyTableHudController MoneyTableHudController { get; set; }

        private void Start()
        {
            GameHudController.Start();
            MoneyTableHudController.Start();
            MainMenuHudController.Start();
        }

        public void OnSoundButtonClick() => MainMenuHudController.SoundButtonSwitch();
    }
}
