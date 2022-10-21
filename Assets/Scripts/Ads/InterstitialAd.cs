using UnityEngine;
using UnityEngine.Advertisements;

namespace Ads
{
    [System.Serializable]
    public class InterstitialAd : IUnityAdsShowListener, IUnityAdsLoadListener
    {
        [SerializeField] private string _androidAdId = "Interstitial_Android";
        [SerializeField] private string _iosAdId = "Interstitial_iOS";

        private string _adId;

        private void LoadAd() => Advertisement.Load(_adId, this);
        public void ShowAd() => Advertisement.Show(_adId, this);

        public void Initialize()
        {
            _adId = Application.platform == RuntimePlatform.IPhonePlayer ? _iosAdId : _androidAdId;
            LoadAd();
        }

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState) => LoadAd();
        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message) => LoadAd();
        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message) => LoadAd();
    
        public void OnUnityAdsShowStart(string placementId) {}
        public void OnUnityAdsShowClick(string placementId) {}
        public void OnUnityAdsAdLoaded(string placementId) {}
    }
}
