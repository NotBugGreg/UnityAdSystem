using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using PlayFab;
using PlayFab.ClientModels;
using UnityEngine;

namespace Submodules.UnityAdSystem.Assets.Code.Basic_Implementation.Installers
{
    public class PlayfabRewardAdsService: IAdPlacement
    {
        public List<AdPlacementDetails> Placements;
        private readonly string _appId;
        private readonly string _identifierAd;

        public PlayfabRewardAdsService(string appId, string identifierAd)
        {
            _appId = appId;
            _identifierAd = identifierAd;
        }
        public Task InitAdPlacements()
        {
            var t = new TaskCompletionSource<bool>();

            GetPlacements(t);
            
            return Task.Run(() => t.Task);
        }


        private void GetPlacements(TaskCompletionSource<bool> taskCompletionSource)
        {
            var request = new GetAdPlacementsRequest
                {AppId = _appId,Identifier = new NameIdentifier {Name = _identifierAd}};

            PlayFabClientAPI.GetAdPlacements(request, result => OnSuccess(result, taskCompletionSource),
                error => OnError(error, taskCompletionSource));
            
        }

        private void OnError(PlayFabError error, TaskCompletionSource<bool> taskCompletionSource)
        {
            taskCompletionSource.SetResult(false);
            throw new Exception(error.GenerateErrorReport());
        }

        private void OnSuccess(GetAdPlacementsResult result, TaskCompletionSource<bool> taskCompletionSource)
        {
            Placements = result.AdPlacements;
            taskCompletionSource.SetResult(true);
            Debug.Log("placements: " + Placements.Count);
        }


    }
}