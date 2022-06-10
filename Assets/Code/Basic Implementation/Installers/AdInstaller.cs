using System;
using System.Linq;
using System.Threading.Tasks;
using PlayFab.ClientModels;
using Submodules.BaseModule.Code.UnityConfigurationAdapter.Installers;


namespace Submodules.UnityAdSystem.Assets.Code.Basic_Implementation.Installers
{
    public class AdInstaller : IInstaller
    {
        private AdPlacementDetails _adPlacementDetails;
        public GoogleAdmob GoogleAdmob;
        
        public async Task InitInstaller()
        {
            var adPlacementService = new PlayfabRewardAdsService(PlayfabAdConfiguration.APP_ID_AD,
                PlayfabAdConfiguration.NAME_ONE_VIDEO_THREE_HINTS_UNIT_ID);
            var placementAdsUseCase = new InitAdPlacementsUseCase(adPlacementService);
            var placementsAds = await placementAdsUseCase.GetAdPlacements();
            _adPlacementDetails = placementsAds.FirstOrDefault();
            
            if (_adPlacementDetails != null)
                GoogleAdmob = new GoogleAdmob(_adPlacementDetails.PlacementId, _adPlacementDetails.RewardId,
                    PlayfabAdConfiguration.ONE_VIDEO_THREE_HINTS_UNIT_ID);
            else
            {
                throw new SystemException("No adplacements details");
            }
        }
    }
}