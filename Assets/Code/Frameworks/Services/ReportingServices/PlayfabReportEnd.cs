using System.Threading.Tasks;
using PlayFab;
using PlayFab.ClientModels;
using Submodules.UnityAdSystem.Assets.Code.Frameworks.Services.ReportingServices;

namespace Submodules.UnityAdSystem.Assets.Code.Frameworks.Services
{
    public class PlayfabReportEndService : PlayfabReportAdActivity
    {
        protected override ReportAdActivityRequest CreateRequest()
        {
            var reportAdActivityRequester = new ReportAdActivityRequest
                {Activity = AdActivity.End, PlacementId = PlacementID, RewardId = RewardID};

            return reportAdActivityRequester;
        }

        public PlayfabReportEndService(string placementID, string rewardID) : base(placementID, rewardID)
        {
        }
    }
}