using GUI.GuiHandler.ADMenuHUD;
using GUI.GuiHandler.GameHUD;
using GUI.GuiHandler.GameOverHUD;
using GUI.GuiHandler.MainMenuHUD;
using GUI.GuiHandler.MoneyPanelHUD;
using GUI.GuiHandler.PauseMenuHUD;
using GUI.GuiHandler.SkinMenuHUD;
using UnityEngine;
using UnityEngine.Events;

namespace GUI.GuiHandler
{
    public class Gui : MonoBehaviour
    {
        #region Singleton

        public static Gui Instance { get; private set; }
        private void Awake()
        {
            if (Instance == null) Instance = this;
            else Destroy(gameObject);
        }

        #endregion
        
        private UnityEvent _onUpdateEvent = new();

        [field: SerializeField] public AxeEngine AxeEngine { get; private set; }
        [field: SerializeField] public GameViewController GameViewController { get; private set; }
        [field: SerializeField] public MainMenuViewController MainMenuViewController { get; private set; }
        [field: SerializeField] public MoneyPanelViewController MoneyPanelViewController { get; private set; }
        [field: SerializeField] public AdMenuViewController AdMenuViewController { get; private set; }
        [field: SerializeField] public SkinMenuViewController SkinMenuViewController { get; private set; }
        [field: SerializeField] public PauseMenuViewController PauseMenuViewController { get; private set; }
        [field: SerializeField] public GameOverViewController GameOverViewController { get; private set; }

        private void Start()
        {
            MainMenuViewController.Initialize(this, _onUpdateEvent);
            AdMenuViewController.Initialize(this, _onUpdateEvent);
            GameViewController.Initialize(this, _onUpdateEvent);
            MoneyPanelViewController.Initialize(this, _onUpdateEvent);
            PauseMenuViewController.Initialize(this, _onUpdateEvent);
            SkinMenuViewController.Initialize(this, _onUpdateEvent);
            GameOverViewController.Initialize(this, _onUpdateEvent);
        }

        private void Update() => _onUpdateEvent?.Invoke();
    }
}