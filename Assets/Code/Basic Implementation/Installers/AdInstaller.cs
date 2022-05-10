using System;
using System.Linq;
using System.Threading.Tasks;
using PlayFab.ClientModels;
using Submodules.BaseModule.UnityConfigurationAdapter.Installers;

namespace Submodules.UnityAdSystem.Assets.Code.Basic_Implementation.Installers
{
    public class AdInstaller : IInstaller
    {
        private AdPlacementDetails _adPlacementDetails;
        public GoogleAdmob GoogleAdmob;
        
        public async Task InitInstaller()
        {
            var adPlacementService = new PlayfabRewardAdsService(PlayfabAdConfiguration.APP_ID_AD,
                PlayfabAdConfiguration.NAME_ONE_VIDEO_THREE_HINTS_UNIT_ID_TEST);
            var placementAdsUseCase = new PlacementAdsUserCase(adPlacementService);
            var placementsAds = await placementAdsUseCase.GetAdPlacements();
            _adPlacementDetails = placementsAds.FirstOrDefault();
            
            if (_adPlacementDetails != null)
                GoogleAdmob = new GoogleAdmob(_adPlacementDetails.PlacementId, _adPlacementDetails.RewardId,
                    PlayfabAdConfiguration.NAME_ONE_VIDEO_THREE_HINTS_UNIT_ID_TEST);
            else
            {
                throw new SystemException("No adplacements details");
            }
        }
    }
}