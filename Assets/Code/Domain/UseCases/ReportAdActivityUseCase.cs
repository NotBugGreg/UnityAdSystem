using System.Threading.Tasks;
using PlayFab.ClientModels;
using Submodules.UnityAdSystem.Assets.Code.Domain.Services;
using Submodules.UnityAdSystem.Assets.Code.Frameworks.Services;
using Submodules.UnityAdSystem.Assets.Code.InterfaceAdapters;
using Submodules.UnityAdSystem.Assets.Code.InterfaceAdapters.Gateways;

namespace Submodules.UnityAdSystem.Assets.Code.Domain
{
    public class ReportAdActivityUseCase : IReportAdActivityRequester
    {
        private readonly IAdService _adService;
        private readonly IReportGateway _reportGateway;

        public ReportAdActivityUseCase(IReportGateway reportGateway, IAdService adServiceImpl)
        {
            _adService = adServiceImpl;
            _reportGateway = reportGateway;
        }

        public void ReportingAd()
        {
            _adService.SetObserver(ListenerRewardStatus);
        }

        private void ListenerRewardStatus(RewardedAdStatus result)
        {
            _reportGateway?.InitAdReporting(result);
        }
    }
}