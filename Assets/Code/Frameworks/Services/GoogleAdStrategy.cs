using System;
using GoogleMobileAds.Api;
using Submodules.UnityAdSystem.Assets.Code.InterfaceAdapters;

namespace Submodules.UnityAdSystem.Assets.Code.Frameworks.Services
{
    public class GoogleAdStrategy : IAdSDKAdapter
    {
        private AdConf _configuration;
        private Action<RewardedAdStatusInterfaceAdapter> _callback;
        private RewardedAd _rewardedAd;

        public void ShowRewardedAd()
        {
            if (!_rewardedAd.IsLoaded()) return;
            _rewardedAd.Show();
        }
        

        public void LoadRewardedAd()
        {
            _rewardedAd = new RewardedAd(_configuration.RewardAdId);
            ConfigureRewardAdEvents();
            var request = new AdRequest.Builder().Build();
            _rewardedAd.LoadAd(request);
        }

        
        
        public void SetCallbackRewardedAd(Action<RewardedAdStatusInterfaceAdapter> callback)
        {
            _callback = callback;
        }

        private void ConfigureRewardAdEvents()
        {
            // Called when an ad request has successfully loaded.
            _rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
            // Called when an ad request failed to load.
            _rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
            // Called when an ad is shown.
            _rewardedAd.OnAdOpening += HandleRewardedAdOpening;
            // Called when an ad request failed to show.
            _rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
            // Called when the user should be rewarded for interacting with the ad.
            _rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
            // Called when the ad is closed.
            _rewardedAd.OnAdClosed += HandleRewardedAdClosed;
        }

        private void HandleRewardedAdClosed(object sender, EventArgs e)
        {
            _callback.Invoke(RewardedAdStatusInterfaceAdapter.RewardedAdClosed);
        }

        private void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs e)
        {
            _callback.Invoke(RewardedAdStatusInterfaceAdapter.RewardedAdFailedToShow);

        }

        private void HandleUserEarnedReward(object sender, Reward e)
        {
            _callback.Invoke(RewardedAdStatusInterfaceAdapter.HandleUserEarnedReward);
        }

        private void HandleRewardedAdOpening(object sender, EventArgs e)
        {
            _callback.Invoke(RewardedAdStatusInterfaceAdapter.RewardedAdOpening);
        }

        private void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs e)
        {
            _callback.Invoke(RewardedAdStatusInterfaceAdapter.RewardedAdFailedToLoad);
        }

        private void HandleRewardedAdLoaded(object sender, EventArgs e)
        {
            _callback.Invoke(RewardedAdStatusInterfaceAdapter.RewardedAdLoaded);
        }

        public void Init(AdConf configuration)
        {
            //var deviceIds = new List<string>();
            //deviceIds.Add("AEB928235AFC892C31F711F5D9BF5A6B");
            _configuration = configuration;
            MobileAds.Initialize(HandleInitialization);

            var requestConfiguration = new RequestConfiguration
                    .Builder()
                .SetTestDeviceIds(_configuration.TestDevices)
                .build();

            MobileAds.SetRequestConfiguration(requestConfiguration);
        }

        private void HandleInitialization(InitializationStatus initStatus)
        {
            _callback.Invoke(RewardedAdStatusInterfaceAdapter.InitializationComplete);
        }
    }
}