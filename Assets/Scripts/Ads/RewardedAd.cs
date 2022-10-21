using UnityEngine;
using UnityEngine.Advertisements;
using UnityEngine.Events;
using UnityEngine.UI;

namespace Ads
{
    [System.Serializable]
    public class RewardedAd : IUnityAdsShowListener, IUnityAdsLoadListener
    {
        [SerializeField] private string _androidAdId = "Rewarded_Android";
        [SerializeField] private string _iosAdId = "Rewarded_iOS";

        private string _adId;
        private UnityEvent _rewardEvent = new();

        private void LoadAd() => Advertisement.Load(_adId, this);
        private void ShowAd() => Advertisement.Show(_adId, this);

        public void Initialize(UnityAction rewardAction, Button.ButtonClickedEvent onClick)
        {
            onClick.AddListener(ShowAd);
        
            _rewardEvent.AddListener(rewardAction);
            _adId = Application.platform == RuntimePlatform.IPhonePlayer ? _iosAdId : _androidAdId;
        
            LoadAd();
        }

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {
            if (_adId == placementId && showCompletionState == UnityAdsShowCompletionState.COMPLETED)
            {
                _rewardEvent?.Invoke();
            }
        
            LoadAd();
        }
    
        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) => LoadAd();
        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message) => LoadAd();
    
        public void OnUnityAdsShowStart(string placementId) {}
        public void OnUnityAdsShowClick(string placementId) {}
        public void OnUnityAdsAdLoaded(string placementId) {}
    }
}
