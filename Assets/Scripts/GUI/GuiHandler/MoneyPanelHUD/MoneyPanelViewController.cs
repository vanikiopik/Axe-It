using Ads;
using UnityEngine;
using UnityEngine.Events;

namespace GUI.GuiHandler.MoneyPanelHUD
{
    [System.Serializable]
    public class MoneyPanelViewController : UiController<MoneyPanelView>
    {
        [SerializeField] private RewardedAd _rewardedAd;
        
        [Min(0)][SerializeField] private int _reward;

        [Tooltip("Cooldown of watching advertisement in seconds")]
        [Min(0)][SerializeField] private float _adCooldown;

        private Timer _timer;
        
        public bool Interactable
        {
            get => View.AddMoneyButton.interactable;
            set => View.AddMoneyButton.interactable = value;
        }

        public override void Initialize(Gui gui, UnityEvent onUpdate)
        {
            base.Initialize(gui, onUpdate);
            Gui.MoneyCounter.OnCoinsChanged.AddListener(SetMoneyText);
            
            _rewardedAd.Initialize(GetReward, View.AddMoneyButton.onClick);
            _timer = new Timer("NextAdWatchDateTime", _adCooldown);
        }

        protected override void Update()
        {
            Interactable = _timer.IsEventCanBe && Gui.MainMenuViewController.View.gameObject.activeSelf;
        }

        public void SetMoneyText(int amount)
        {
            View.MoneyText.text = amount.ToString();
        }

        private void GetReward()
        {
            Gui.MoneyCounter.AddCoins(_reward);
            _timer.Reset();
            Interactable = false;
        }
    }
}