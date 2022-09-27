using GUI.ADMenuHUD;
using GUI.GameHUD;
using GUI.GameOverHUD;
using GUI.MainMenuHUD;
using GUI.MoneyPanelHUD;
using GUI.PauseMenuHUD;
using GUI.SkinMenuHUD;
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
            else Destroy(gameObject);
        }

        #endregion

        [field: SerializeField] public GameViewController GameViewController { get; set; }
        [field: SerializeField] public MainMenuViewController MainMenuViewController { get; set; }
        [field: SerializeField] public MoneyPanelViewController MoneyPanelViewController { get; set; }
        [field: SerializeField] public AdMenuViewController AdMenuViewController { get; set; }
        [field: SerializeField] public SkinMenuViewController SkinMenuViewController { get; set; }
        [field: SerializeField] public PauseMenuViewController PauseMenuViewController { get; set; }
        [field: SerializeField] public GameOverViewController GameOverViewController { get; set; }
        public Axe Axe { get; private set; }

        private void Start()
        {
            Axe = FindObjectOfType<Axe>();
            MainMenuViewController.Start(this);
            AdMenuViewController.Start(this);
            GameViewController.Start(this);
            MoneyPanelViewController.Start(this);
            PauseMenuViewController.Start(this);
            SkinMenuViewController.Start(this);
            GameOverViewController.Start(this);
        }
    }
}