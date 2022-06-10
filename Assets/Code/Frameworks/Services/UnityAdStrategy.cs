using System;
using Submodules.UnityAdSystem.Assets.Code.InterfaceAdapters;
using UnityEngine.Advertisements;

namespace Submodules.UnityAdSystem.Assets.Code.Frameworks.Services
{
    public class UnityAdStrategy : IAdSDKAdapter, IUnityAdsInitializationListener,
        IUnityAdsLoadListener, IUnityAdsShowListener
    {
        private AdConf _configuration;
        private Action<RewardedAdStatusInterfaceAdapter> _callback;


        public void ShowRewardedAd()
        {
            Advertisement.Show(_configuration.RewardAdId, this);
        }

        public void LoadRewardedAd()
        {
            Advertisement.Load(_configuration.RewardAdId, this);
        }

        public void SetCallbackRewardedAd(Action<RewardedAdStatusInterfaceAdapter> callback)
        {
            _callback = callback;
        }


        public void Init(AdConf configuration)
        {
            _configuration = configuration;
            Advertisement.Initialize(configuration.GameId,
                true,
                true);
        }

        public void OnInitializationComplete()
        {
        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
        }

        public void OnUnityAdsAdLoaded(string placementId)
        {
        }

        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
        {
        }

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
            _callback.Invoke(RewardedAdStatusInterfaceAdapter.Error);
        }

        public void OnUnityAdsShowStart(string placementId)
        {
        }

        public void OnUnityAdsShowClick(string placementId)
        {
        }

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {
            switch (showCompletionState)
            {
                case UnityAdsShowCompletionState.COMPLETED:
                    _callback.Invoke(RewardedAdStatusInterfaceAdapter.Ok);
                    break;
                case UnityAdsShowCompletionState.UNKNOWN:
                case UnityAdsShowCompletionState.SKIPPED:
                    _callback.Invoke(RewardedAdStatusInterfaceAdapter.Cancel);
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(showCompletionState), showCompletionState, null);
            }
        }
    }
}