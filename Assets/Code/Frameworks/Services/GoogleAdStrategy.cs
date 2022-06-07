using System;
using GoogleMobileAds.Api;
using InterfaceAdapters;
using Submodules.UnityAdSystem.Assets.Code.InterfaceAdapters;

namespace Submodules.UnityAdSystem.Assets.Code.Frameworks.Services
{
    public class GoogleAdStrategy : AdSDKAdapter
    {
        private AdConf _configuration;
        private Action<RewardedAdStatus> _callback;
        private RewardedAd _rewardedAd;

        public void ShowRewardedAd(Action<RewardedAdStatus> callback)
        {
            if (!_rewardedAd.IsLoaded()) return;

            _rewardedAd.Show();
        }

        public void LoadRewardedAd()
        {
            _rewardedAd = new RewardedAd(_configuration.RewardAdId);
            var request = new AdRequest.Builder().Build();
            _rewardedAd.LoadAd(request);
        }

        private void ConfigureEvents()
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
            throw new NotImplementedException();
        }

        private void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs e)
        {
            _callback.Invoke(RewardedAdStatus.Error);
        }

        private void HandleUserEarnedReward(object sender, Reward e)
        {
            throw new NotImplementedException();
        }

        private void HandleRewardedAdOpening(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        private void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs e)
        {
            _callback.Invoke(RewardedAdStatus.Error);
        }

        private void HandleRewardedAdLoaded(object sender, EventArgs e)
        {
            _callback.Invoke(RewardedAdStatus.Ok);

        }

        public void Init(AdConf configuration)
        {
            //var deviceIds = new List<string>();
            //deviceIds.Add("AEB928235AFC892C31F711F5D9BF5A6B");

            _configuration = configuration;
            MobileAds.Initialize(initStatus => { });

            var requestConfiguration = new RequestConfiguration
                    .Builder()
                .SetTestDeviceIds(_configuration.TestDevices)
                .build();

            MobileAds.SetRequestConfiguration(requestConfiguration);
        }
    }
}