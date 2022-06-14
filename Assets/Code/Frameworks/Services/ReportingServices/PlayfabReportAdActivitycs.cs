using System;
using System.Threading.Tasks;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

namespace Submodules.UnityAdSystem.Assets.Code.Frameworks.Services.ReportingServices
{
    public abstract class PlayfabReportAdActivity : IReportAdActivity
    {
        protected readonly string PlacementID;
        protected readonly string RewardID;

        protected PlayfabReportAdActivity(string placementID, string rewardID)
        {
            PlacementID = placementID;
            RewardID = rewardID;
        }

        public Task<ReportAdActivityResult> InitAdReporting()
        {
            var t = new TaskCompletionSource<ReportAdActivityResult>();

            var request = CreateRequest();
            SendAdReport(request, t);

            return Task.Run(() => t.Task);
        }

        protected abstract ReportAdActivityRequest CreateRequest();

        private void SendAdReport(ReportAdActivityRequest reportAdActivityRequester,
            TaskCompletionSource<ReportAdActivityResult> taskCompletionSource)
        {
            PlayFabClientAPI.ReportAdActivity(reportAdActivityRequester
                ,
                result => OnSuccess(result, taskCompletionSource),
                error => OnError(error, taskCompletionSource));
        }

        private void OnError(PlayFabError error, TaskCompletionSource<ReportAdActivityResult> taskCompletionSource)
        {
            taskCompletionSource.SetCanceled();
            throw new Exception(error.GenerateErrorReport());
        }

        private void OnSuccess(ReportAdActivityResult result,
            TaskCompletionSource<ReportAdActivityResult> taskCompletionSource)
        {
            taskCompletionSource.SetResult(result);
            Debug.Log(result.ToString());
        }
    }
}