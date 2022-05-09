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
        public List<AdPlacementDetails> PlacementsDetails;
        private readonly string _appId;
        private readonly string _identifierAd;

        public PlayfabRewardAdsService(string appId, string identifierAd)
        {
            _appId = appId;
            _identifierAd = identifierAd;
        }
        public Task<List<AdPlacementDetails>> InitAdPlacements()
        {
            var t = new TaskCompletionSource<List<AdPlacementDetails>>();

            GetPlacements(t);
            
            return Task.Run(() => t.Task);
        }


        private void GetPlacements(TaskCompletionSource<List<AdPlacementDetails>> taskCompletionSource)
        {
            var request = new GetAdPlacementsRequest
                {AppId = _appId,Identifier = new NameIdentifier {Name = _identifierAd}};

            PlayFabClientAPI.GetAdPlacements(request, result => OnSuccess(result, taskCompletionSource),
                error => OnError(error, taskCompletionSource));
            
        }

        private void OnError(PlayFabError error, TaskCompletionSource<List<AdPlacementDetails>> taskCompletionSource)
        {
            taskCompletionSource.SetCanceled();
            throw new Exception(error.GenerateErrorReport());
        }

        private void OnSuccess(GetAdPlacementsResult result, TaskCompletionSource<List<AdPlacementDetails>> taskCompletionSource)
        {
            PlacementsDetails = result.AdPlacements;
            taskCompletionSource.SetResult(PlacementsDetails);
            Debug.Log("placements: " + PlacementsDetails.Count);
        }


    }
}