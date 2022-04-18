using System.Threading.Tasks;

namespace Submodules.UnityAdSystem.Assets.Code.Basic_Implementation.Installers
{
    internal class RewardPlacementAdsUserCase: IAdPlacementRequester
    {
        private readonly IAdPlacement _adPlacementService;
        public RewardPlacementAdsUserCase(IAdPlacement adPlacementService)
        {
            _adPlacementService = adPlacementService;
        }

        public Task GetAdPlacements()
        {
            return _adPlacementService.InitAdPlacements();
        }
    }
}