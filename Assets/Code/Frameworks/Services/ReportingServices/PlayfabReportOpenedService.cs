using PlayFab.ClientModels;
using Submodules.UnityAdSystem.Assets.Code.Frameworks.Services.ReportingServices;

namespace Submodules.UnityAdSystem.Assets.Code.Frameworks.Services
{
    public class PlayfabReportOpenedService : PlayfabReportAdActivity
    {
        protected override ReportAdActivityRequest CreateRequest()
        {
            var reportAdActivityRequester = new ReportAdActivityRequest
                {Activity = AdActivity.Opened, PlacementId = PlacementID, RewardId = RewardID};

            return reportAdActivityRequester;
        }

        public PlayfabReportOpenedService(string placementID, string rewardID) : base(placementID, rewardID)
        {
        }
    }
}