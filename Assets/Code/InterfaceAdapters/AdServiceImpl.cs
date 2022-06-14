using System;
using Submodules.UnityAdSystem.Assets.Code.Domain;
using Submodules.UnityAdSystem.Assets.Code.Domain.Services;

namespace Submodules.UnityAdSystem.Assets.Code.InterfaceAdapters
{
    public class AdServiceImpl : IAdService
    {
        private readonly IAdSDKAdapter _mainProvider;
        private Action<RewardedAdStatus> _adServiceCallBack;

        public AdServiceImpl(IAdSDKAdapter mainProvider)
        {
            _mainProvider = mainProvider;
        }

        public void SetStatusRewardedAdCallback()
        {
            _mainProvider.SetCallbackRewardedAd(OnRewardedStatusListener);
        }

        public void SetObserver(Action <RewardedAdStatus> callback)
        {
            _adServiceCallBack += callback;
        }
        

        public void ShowRewardedAd()
        {
            _mainProvider.ShowRewardedAd();
        }


        public void LoadRewardedAd()
        {
            _mainProvider.LoadRewardedAd();
        }
        

        public void Init(AdConfiguration adConfiguration)
        {
            var adConf = new AdConf(adConfiguration.AdId);
            _mainProvider.Init(adConf);
        }

        private void OnRewardedStatusListener(RewardedAdStatusInterfaceAdapter status)
        {
            var rewardedAdStatus = MapStatus(status);
            _adServiceCallBack.Invoke(rewardedAdStatus);
        }

        private static RewardedAdStatus MapStatus(RewardedAdStatusInterfaceAdapter status)
        {
            return status switch
            {
                RewardedAdStatusInterfaceAdapter.InitializationComplete => RewardedAdStatus.InitializationComplete,
                RewardedAdStatusInterfaceAdapter.InitializationFailed => RewardedAdStatus.InitializationFailed,
                RewardedAdStatusInterfaceAdapter.RewardedClicked => RewardedAdStatus.RewardedClicked,
                RewardedAdStatusInterfaceAdapter.RewardedAdClosed => RewardedAdStatus.RewardedAdClosed,
                RewardedAdStatusInterfaceAdapter.RewardedAdLoaded => RewardedAdStatus.RewardedAdLoaded,
                RewardedAdStatusInterfaceAdapter.RewardedAdOpening => RewardedAdStatus.RewardedAdOpening,
                RewardedAdStatusInterfaceAdapter.HandleUserEarnedReward => RewardedAdStatus.HandleUserEarnedReward,
                RewardedAdStatusInterfaceAdapter.RewardedAdFailedToLoad => RewardedAdStatus.RewardedAdFailedToLoad,
                RewardedAdStatusInterfaceAdapter.RewardedAdFailedToShow => RewardedAdStatus.RewardedAdFailedToShow,
                _ => throw new ArgumentOutOfRangeException(nameof(status), status, null)
            };
        }
    }
}