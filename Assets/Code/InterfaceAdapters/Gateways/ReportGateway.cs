using System.Threading.Tasks;
using JetBrains.Annotations;
using PlayFab.ClientModels;
using Submodules.UnityAdSystem.Assets.Code.Domain;
using Submodules.UnityAdSystem.Assets.Code.Domain.Services;
using Submodules.UnityAdSystem.Assets.Code.Frameworks.Services;
using Submodules.UnityAdSystem.Assets.Code.Frameworks.Services.ReportingServices;

namespace Submodules.UnityAdSystem.Assets.Code.InterfaceAdapters.Gateways
{
    public class ReportGateway : IReportGateway
    {
        [CanBeNull] private IReportAdActivity _reportAdActivity;
        private readonly string _placementID;
        private readonly string _rewardID;

        public ReportGateway(string placementID, string rewardID)
        {
            _placementID = placementID;
            _rewardID = rewardID;
        }

        public async void InitAdReporting(RewardedAdStatus rewardedAdStatus)
        {
            switch (rewardedAdStatus)
            {
                case RewardedAdStatus.RewardedAdLoaded:
                    _reportAdActivity = new PlayfabReportStartService(_placementID, _rewardID);
                    break;
                case RewardedAdStatus.RewardedAdOpening:
                    _reportAdActivity = new PlayfabReportOpenedService(_placementID, _rewardID);
                    break;
                case RewardedAdStatus.RewardedAdClosed:
                    _reportAdActivity = new PlayfabReportCloseService(_placementID, _rewardID);
                    break;
                case RewardedAdStatus.HandleUserEarnedReward:
                    _reportAdActivity = new PlayfabReportEndService(_placementID, _rewardID);
                    break;
            }

            if (_reportAdActivity != null)
                await _reportAdActivity.InitAdReporting();
        }
    }
}