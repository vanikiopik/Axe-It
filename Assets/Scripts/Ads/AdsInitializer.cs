using UnityEngine;
using UnityEngine.Advertisements;

namespace Ads
{
    public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
    {
        [SerializeField] private string _androidGameId = "4982583";
        [SerializeField] private string _iosGameId = "4982582";
        [SerializeField] private bool _isTestMode = true;
    
        private void Awake()
        {
            string gameId = Application.platform == RuntimePlatform.IPhonePlayer ? _iosGameId : _androidGameId;
            Advertisement.Initialize(gameId, _isTestMode, this);

            Application.targetFrameRate = 300;
            QualitySettings.vSyncCount = 0;
        }

        public void OnInitializationComplete() {}
        public void OnInitializationFailed(UnityAdsInitializationError error, string message) {}
    }
}
