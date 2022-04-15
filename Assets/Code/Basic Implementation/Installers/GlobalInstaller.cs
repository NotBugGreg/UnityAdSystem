using System;
using System.Linq;
using System.Threading.Tasks;
using PlayFab.ClientModels;
using UnityEngine;
using UnityEngine.UI;

namespace Submodules.UnityAdSystem.Assets.Code.Basic_Implementation.Installers
{
    public class GlobalInstaller : MonoBehaviour
    {
        public Button showRewardAdButton;
        private AdPlacementDetails _placement;
        private void Awake()
        {
            showRewardAdButton.onClick.AddListener(InitShowRewardAd);
        }

        private void InitShowRewardAd()
        {
            var adPlacementService = new PlayfabRewardAdsService(PlayfabAdConfiguration.APP_ID_AD,
                PlayfabAdConfiguration.NAME_ONE_VIDEO_THREE_HINTS_UNIT_ID_TEST);
            var rewardPlacementAdsUseCase = new RewardPlacementAdsUserCase(adPlacementService);
            var initializeGame = new InitializeGameUseCase(rewardPlacementAdsUseCase);
            InitializeGoogleAdmob(initializeGame, adPlacementService);
        }

        private async void  InitializeGoogleAdmob(InitializeGameUseCase initializeGame, PlayfabRewardAdsService adPlacementService)
        {
            var placement = await InitializeGameMethod(initializeGame, adPlacementService);
            StartGoogleAdmob(placement);
        }
        
        private async Task<AdPlacementDetails> InitializeGameMethod(InitializeGameUseCase initializeGame,
            PlayfabRewardAdsService playfabRewardAdsService)
        {
            await initializeGame.InitGameAsync();
            var placementsAds = playfabRewardAdsService.Placements;
            _placement = placementsAds.FirstOrDefault() ??
                         throw new ArgumentNullException("placementsAds.FirstOrDefault()");

            return _placement;
        }


        private void StartGoogleAdmob(AdPlacementDetails adPlacementDetails)
        {
            var googleAdmob = new GoogleAdmob(adPlacementDetails.PlacementId, adPlacementDetails.RewardId, PlayfabAdConfiguration.ONE_VIDEO_THREE_HINTS_UNIT_ID_TEST);
            googleAdmob.ConfigurationMobileAds();
            googleAdmob.RequestRewardedAd();
            googleAdmob.ConfigureEvents();
            googleAdmob.UserChoseToWatchAd();
        }
    }
}