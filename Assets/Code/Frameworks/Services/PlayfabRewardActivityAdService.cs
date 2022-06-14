using System;
using System.Threading.Tasks;
using PlayFab;
using PlayFab.ClientModels;
using Submodules.UnityAdSystem.Assets.Code.Domain.Services;
using UnityEngine;

namespace Submodules.UnityAdSystem.Assets.Code.Frameworks.Services
{
    public class PlayfabRewardActivityAdService : IRewardActivityAd
    {
        private readonly string _placementID;
        private readonly string _rewardID;

        public PlayfabRewardActivityAdService(string placementID, string rewardID)
        {
            _placementID = placementID;
            _rewardID = rewardID;
        }

        public Task<RewardAdActivityResult> InitRewardAdReporting()
        {
            var t = new TaskCompletionSource<RewardAdActivityResult>();

            NotificationActivityReward(t);

            return Task.Run(() => t.Task);
        }


        private void NotificationActivityReward(TaskCompletionSource<RewardAdActivityResult> taskCompletionSource)
        {
            var rewardAdActivity = new RewardAdActivityRequest
            {
                PlacementId = _placementID,
                RewardId = _rewardID
            };

            PlayFabClientAPI.RewardAdActivity(rewardAdActivity, result => OnSuccess(result, taskCompletionSource),
                error => OnError(error, taskCompletionSource));
        }

        private void OnError(PlayFabError error, TaskCompletionSource<RewardAdActivityResult> taskCompletionSource)
        {
            taskCompletionSource.SetCanceled();
            throw new Exception(error.GenerateErrorReport());
        }

        private void OnSuccess(RewardAdActivityResult result,
            TaskCompletionSource<RewardAdActivityResult> taskCompletionSource)
        {
            taskCompletionSource.SetResult(result);
            Debug.Log(result.ToString());
        }

    }
}