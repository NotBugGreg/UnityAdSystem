using System.Threading.Tasks;
using PlayFab.ClientModels;

namespace Submodules.UnityAdSystem.Assets.Code.Frameworks.Services
{
    public interface IReportAdActivityRequester
    {
        public Task<ReportAdActivityResult> ReportingAd();
    }
}