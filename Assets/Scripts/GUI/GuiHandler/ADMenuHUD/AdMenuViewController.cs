using System;
using UnityEngine;
using UnityEngine.Events;

namespace GUI.GuiHandler.ADMenuHUD
{
    [Serializable]
    public class AdMenuViewController : UiController<AdMenuView>
    {
        [Min(0)][SerializeField] private int _reward;
        
        [Tooltip("Cooldown of watching advertisement in seconds")]
        [Min(0)][SerializeField] private float _adCooldown;

        private Timer _timer;
        
        public override void Initialize(Gui gui, UnityEvent onUpdate)
        {
            base.Initialize(gui, onUpdate);
            View.AwardAmountText.text = _reward.ToString();
            View.CloseButton.onClick.AddListener(OnCloseButtonClick);
            View.AdWatchButton.onClick.AddListener(OnWatchButtonClick);

            _timer = new Timer("NextAdWatchDateTime", _adCooldown);
        }

        protected override void Update()
        {
            View.CooldownText.text = $"You can get reward in\n{_timer.SpanMinutes}:{_timer.SpanSeconds}";
            SetWatchButtonVisible(_timer.IsEventCanBe);
        }

        private void SetWatchButtonVisible(bool watchButtonVisible)
        {
            View.AdWatchButton.gameObject.SetActive(watchButtonVisible);
            View.CooldownText.gameObject.SetActive(!watchButtonVisible);
        }

        private void OnCloseButtonClick()
        {
            Gui.AdMenuViewController.SetActive(false);
            Gui.MainMenuViewController.SetActive(true);
        }

        private void OnWatchButtonClick()
        {
            /* TODO - watch advertisement */

            if (true /* TODO - check if AD watched full */)
            {
                Gui.MoneyCounter.AddCoins(_reward);
                _timer.Reset();
            }
        }
    }
}