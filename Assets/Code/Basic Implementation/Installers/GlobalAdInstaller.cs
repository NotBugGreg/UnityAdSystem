using System;
using System.Linq;
using System.Threading.Tasks;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

namespace Submodules.UnityAdSystem.Assets.Code.Basic_Implementation.Installers
{
    public class GlobalAdInstaller 
    {
        private AdPlacementDetails _adPlacementDetails;
        private GoogleAdmob _googleAdmob;

        public GlobalAdInstaller(Button showRewardAdButton)
        {
            showRewardAdButton.onClick.AddListener(ShowGoogleAdmob);
        }
        public void InitShowRewardAd()
        {
            var adPlacementService = new PlayfabRewardAdsService(PlayfabAdConfiguration.APP_ID_AD,
                PlayfabAdConfiguration.NAME_ONE_VIDEO_THREE_HINTS_UNIT_ID_TEST);
            var rewardPlacementAdsUseCase = new RewardPlacementAdsUserCase(adPlacementService);
            var initializeGame = new InitializeGameUseCase(rewardPlacementAdsUseCase);
            InitializeGoogleAdmob(initializeGame, adPlacementService);
        }

        private async void  InitializeGoogleAdmob(InitializeGameUseCase initializeGame, PlayfabRewardAdsService adPlacementService)
        {
            _adPlacementDetails = await InitializeGameMethod(initializeGame, adPlacementService);
            _googleAdmob = new GoogleAdmob(_adPlacementDetails.PlacementId, _adPlacementDetails.RewardId, PlayfabAdConfiguration.ONE_VIDEO_THREE_HINTS_UNIT_ID_TEST);
        }
        
        private async Task<AdPlacementDetails> InitializeGameMethod(IGameInitializer initializeGame,
            PlayfabRewardAdsService playfabRewardAdsService)
        {
            await initializeGame.InitGameAsync(null, null);
            var placementsAds = playfabRewardAdsService.Placements;
            return placementsAds.FirstOrDefault() ??
                         throw new ArgumentNullException("placementsAds.FirstOrDefault()");
        }

        private void ShowGoogleAdmob()
        {
            _googleAdmob.UserChoseToWatchAd();
        }
        
    }
}