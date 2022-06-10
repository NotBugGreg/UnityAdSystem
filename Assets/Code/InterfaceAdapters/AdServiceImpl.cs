using System;
using System.Threading.Tasks;
using Domain;
using Submodules.UnityAdSystem.Assets.Code.Domain;

namespace Submodules.UnityAdSystem.Assets.Code.InterfaceAdapters
{
    public class AdServiceImpl : IAdService
    {
        private readonly IAdSDKAdapter _mainProvider;

        public AdServiceImpl(IAdSDKAdapter mainProvider)
        {
            _mainProvider = mainProvider;
        }

        public void ShowRewardedAd()
        {
            _mainProvider.ShowRewardedAd();
        }


        public void LoadRewardedAd()
        {
            _mainProvider.LoadRewardedAd();
        }

        public Task<RewardedAdStatus> DeliverRewardedAd()
        {
            var taskCompletionSource = new TaskCompletionSource<RewardedAdStatus>();
            _mainProvider.SetCallbackRewardedAd(status => OnShowRewardedAdEnded(status, taskCompletionSource));

            return Task.Run(() => taskCompletionSource.Task);
        }


        public void Init(AdConfiguration adConfiguration)
        {
            var adConf = new AdConf(adConfiguration.AdId);
            _mainProvider.Init(adConf);
        }

        private void OnShowRewardedAdEnded(RewardedAdStatusInterfaceAdapter status,
            TaskCompletionSource<RewardedAdStatus> taskCompletionSource)
        {
            var rewardedAdStatus = MapStatus(status);
            taskCompletionSource.SetResult(rewardedAdStatus);
        }

        private static RewardedAdStatus MapStatus(RewardedAdStatusInterfaceAdapter status)
        {
            switch (status)
            {
                case RewardedAdStatusInterfaceAdapter.Ok:
                    return RewardedAdStatus.Ok;
                case RewardedAdStatusInterfaceAdapter.Cancel:
                case RewardedAdStatusInterfaceAdapter.Error:
                    return RewardedAdStatus.Error;
                default:
                    throw new ArgumentOutOfRangeException(nameof(status), status, null);
            }
        }
    }
}