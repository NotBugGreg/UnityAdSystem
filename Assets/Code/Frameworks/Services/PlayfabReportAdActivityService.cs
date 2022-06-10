using System;
using System.Threading.Tasks;
using PlayFab;
using PlayFab.ClientModels;
using Submodules.UnityAdSystem.Assets.Code.Main;
using UnityEngine;

namespace Submodules.UnityAdSystem.Assets.Code.Frameworks.Services
{
    public class PlayfabReportAdActivityService : IReportAdActivity
    {
        private readonly string _placementID;
        private readonly string _rewardID;

        public PlayfabReportAdActivityService(string placementID, string rewardID)
        {
            _placementID = placementID;
            _rewardID = rewardID;
        }
        public Task<ReportAdActivityResult> InitAdReporting()
        {
            var t = new TaskCompletionSource<ReportAdActivityResult>();

            ReportingAdActivity(t);

            return Task.Run(() => t.Task);
        }

        public void ReportingAdActivity(TaskCompletionSource<ReportAdActivityResult> taskCompletionSource)
        {
            var reportAdActivityRequester = new ReportAdActivityRequest
                {Activity = AdActivity.End, PlacementId = _placementID, RewardId = _rewardID};

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
            Debug.Log(result.ToString());
        }
    }
}