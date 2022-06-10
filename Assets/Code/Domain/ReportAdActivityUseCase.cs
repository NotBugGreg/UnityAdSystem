using System.Threading.Tasks;
using PlayFab.ClientModels;
using Submodules.UnityAdSystem.Assets.Code.Frameworks.Services;

namespace Submodules.UnityAdSystem.Assets.Code.Domain
{
    public class ReportAdActivityUseCase : IReportAdActivityRequester
    {
        private readonly PlayfabReportAdActivityService _reportAdActivityService;

        public ReportAdActivityUseCase(PlayfabReportAdActivityService reportAdActivityService)
        {
            _reportAdActivityService = reportAdActivityService;
        }

        public async Task<ReportAdActivityResult> ReportingAd()
        {
            return await _reportAdActivityService.InitAdReporting();
        }
    }
}