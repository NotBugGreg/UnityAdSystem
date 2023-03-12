using System;
using Frameworks.Services;
using Submodules.UnityAdSystem.Assets.Code.Domain;
using Submodules.UnityAdSystem.Assets.Code.InterfaceAdapters;

namespace Submodules.UnityAdSystem.Assets.Code.Frameworks.Services
{
    public class DefaultAdStrategy : IAdSDKAdapter
    {
        private RewardedAd _rewardedAd;
        private readonly RewardedAddLoader _rewardedAddLoader;
        private Action<RewardedAdStatusInterfaceAdapter> _callback;

        private AdConf _conf;

        public DefaultAdStrategy(RewardedAddLoader rewardedAddLoader)
        {
            _rewardedAddLoader = rewardedAddLoader;
        }


        public void ShowRewardedAd()
        {
            if (_rewardedAd == null)
                throw new NullReferenceException("Rewarded ad not loaded");

            _rewardedAd.OnOkButtonPressed += HandleOk;
            _rewardedAd.OnCancelButtonPressed += HandleCancel;
            _rewardedAd.OnErrorButtonPressed += HandleError;

            _rewardedAd.Show();
        }

        public async void LoadRewardedAd()
        {
            _rewardedAd = await _rewardedAddLoader.Load();
        }

        public void SetCallbackRewardedAd(Action<RewardedAdStatusInterfaceAdapter> callback)
        {
            _callback = callback;
        }

        public void Init(AdConf conf)
        {
            _conf = conf;
        }

        public GoogleMobileAds.Api.RewardedAd GetRequestRewardedAd()
        {
            throw new NotImplementedException();
        }

        private void HandleOk()
        {
            ReturnWith(RewardedAdStatusInterfaceAdapter.HandleUserEarnedReward);
            Reset();
        }

        private void HandleCancel()
        {
            ReturnWith(RewardedAdStatusInterfaceAdapter.RewardedAdFailedToShow);
            Reset();
        }

        private void HandleError()
        {
            ReturnWith(RewardedAdStatusInterfaceAdapter.InitializationFailed);
            Reset();
        }

        private void ReturnWith(RewardedAdStatusInterfaceAdapter result)
        {
            _callback(result);
        }

        private void Reset()
        {
            _rewardedAd.Hide();
            _rewardedAd.OnOkButtonPressed -= HandleOk;
            _rewardedAd.OnCancelButtonPressed -= HandleCancel;
            _rewardedAd.OnErrorButtonPressed -= HandleError;
        }
    }
}