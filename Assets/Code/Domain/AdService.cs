using System.Threading.Tasks;
using Domain;

namespace Submodules.UnityAdSystem.Assets.Code.Domain
{
    public interface IAdService
    {
        void ShowRewardedAd();
        void LoadRewardedAd();
        void Init(AdConfiguration adConfiguration);
        Task<RewardedAdStatus> DeliverRewardedAd();
    }
}