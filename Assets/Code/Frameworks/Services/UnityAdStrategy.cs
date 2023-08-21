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
                true);
        }

        public void OnInitializationComplete()
        {
            _callback.Invoke(RewardedAdStatusInterfaceAdapter.InitializationComplete);
        }

        public void OnInitializationFailed(UnityAdsInitializationError error, string message)
        {
            _callback.Invoke(RewardedAdStatusInterfaceAdapter.InitializationFailed);
        }

        public void OnUnityAdsAdLoaded(string placementId)
        {
            _callback.Invoke(RewardedAdStatusInterfaceAdapter.RewardedAdLoaded);
        }

        public void OnUnityAdsFailedToLoad(string placementId, UnityAdsLoadError error, string message)
        {
            _callback.Invoke(RewardedAdStatusInterfaceAdapter.RewardedAdFailedToShow);
        }

        public void OnUnityAdsShowFailure(string placementId, UnityAdsShowError error, string message)
        {
            _callback.Invoke(RewardedAdStatusInterfaceAdapter.RewardedAdFailedToShow);
        }

        public void OnUnityAdsShowStart(string placementId)
        {
            _callback.Invoke(RewardedAdStatusInterfaceAdapter.RewardedAdOpening);
        }

        public void OnUnityAdsShowClick(string placementId)
        {
            _callback.Invoke(RewardedAdStatusInterfaceAdapter.RewardedClicked);
        }

        public void OnUnityAdsShowComplete(string placementId, UnityAdsShowCompletionState showCompletionState)
        {
            _callback.Invoke(RewardedAdStatusInterfaceAdapter.HandleUserEarnedReward);
        }
    }
}