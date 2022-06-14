using PlayFab.ClientModels;

namespace Submodules.UnityAdSystem.Assets.Code.Frameworks.Services.ReportingServices
{
    public class PlayfabReportCloseService : PlayfabReportAdActivity
    {
        protected override ReportAdActivityRequest CreateRequest()
        {
            var reportAdActivityRequester = new ReportAdActivityRequest
                {Activity = AdActivity.Closed, PlacementId = PlacementID, RewardId = RewardID};

            return reportAdActivityRequester;
        }

        public PlayfabReportCloseService(string placementID, string rewardID) : base(placementID, rewardID)
        {
        }
    }
}