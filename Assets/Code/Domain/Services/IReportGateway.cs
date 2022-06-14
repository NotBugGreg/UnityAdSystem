using System.Threading.Tasks;

namespace Submodules.UnityAdSystem.Assets.Code.Domain.Services
{
    public interface IReportGateway
    {
       void InitAdReporting(RewardedAdStatus rewardedAdStatus);
    }
}