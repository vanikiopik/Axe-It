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
        }

        public void OnInitializationComplete()
        {
            Debug.Log("Advertisement initialization is successful");
        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            Debug.Log($"Advertisement initialization is failed: {error} - {message}");
        }
    }
}
