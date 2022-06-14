using Submodules.UnityAdSystem.Assets.Code.Domain.Services;
using Submodules.UnityAdSystem.Assets.Code.Frameworks.Services;

namespace Submodules.UnityAdSystem.Assets.Code.Domain
{
    public class DeliverRewardedAdUseCase
    {
        private readonly IAdService _adService;
        private readonly IRewardActivityAd _rewardActivityRequester;

        public DeliverRewardedAdUseCase(IAdService adService, IRewardActivityAd rewardActivityRequester)
        {
            _adService = adService;
            _rewardActivityRequester = rewardActivityRequester;
        }

        public void DeliverReward()
        {
            _adService.SetObserver(ListenerRewardStatus);
        }

        private async void ListenerRewardStatus(RewardedAdStatus result)
        {
            if (result != RewardedAdStatus.HandleUserEarnedReward) return;

            await _rewardActivityRequester.InitRewardAdReporting();
        }
    }
}