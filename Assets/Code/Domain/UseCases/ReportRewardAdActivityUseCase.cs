using System.Threading.Tasks;
using PlayFab.ClientModels;
using Submodules.UnityAdSystem.Assets.Code.Domain.Services;
using Submodules.UnityAdSystem.Assets.Code.Frameworks.Services;

namespace Submodules.UnityAdSystem.Assets.Code.Domain
{
    public class RewardAdActivityUseCase : IAdActivityRequester
    {
        private readonly IRewardActivityAd _rewardActivityRequester;

        public RewardAdActivityUseCase(IRewardActivityAd rewardActivityRequester)
        {
            _rewardActivityRequester = rewardActivityRequester;
        }

        public async Task<RewardAdActivityResult> ReportRewardAdActivity()
        {
            return await _rewardActivityRequester.InitRewardAdReporting();
        }
    }
}