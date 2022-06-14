using System.Threading.Tasks;
using PlayFab.ClientModels;

namespace Submodules.UnityAdSystem.Assets.Code.Domain.Services
{
    public interface IRewardActivityAd
    {
        public Task<RewardAdActivityResult> InitRewardAdReporting();

    }
}