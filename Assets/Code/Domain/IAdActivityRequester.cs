using System.Threading.Tasks;
using PlayFab.ClientModels;

namespace Submodules.UnityAdSystem.Assets.Code.Domain
{
    public interface IAdActivityRequester
    {
        public Task<RewardAdActivityResult> ReportRewardAdActivity();
    }
}