using PlayFab.ClientModels;

namespace Submodules.UnityAdSystem.Assets.Code.Frameworks.Services.ReportingServices
{
    public class PlayfabReportStartService : PlayfabReportAdActivity
    {
        protected override ReportAdActivityRequest CreateRequest()
        {
            var reportAdActivityRequester = new ReportAdActivityRequest
                {Activity = AdActivity.Start, PlacementId = PlacementID, RewardId = RewardID};

            return reportAdActivityRequester;
        }

        public PlayfabReportStartService(string placementID, string rewardID) : base(placementID, rewardID)
        {
        }
    }
}