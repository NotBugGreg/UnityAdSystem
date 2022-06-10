using System.Threading.Tasks;
using PlayFab.ClientModels;

namespace Submodules.UnityAdSystem.Assets.Code.Frameworks.Services
{
    public interface IRewardActivityAd
    {
        public Task<RewardAdActivityResult> InitRewardAdReporting();

    }
}