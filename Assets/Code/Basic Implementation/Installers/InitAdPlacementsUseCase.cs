using System.Collections.Generic;
using System.Threading.Tasks;
using PlayFab.ClientModels;

namespace Submodules.UnityAdSystem.Assets.Code.Basic_Implementation.Installers
{
    internal class InitAdPlacementsUseCase: IAdPlacementRequester
    {
        private readonly IAdPlacement _adPlacementService;
        public InitAdPlacementsUseCase(IAdPlacement adPlacementService)
        {
            _adPlacementService = adPlacementService;
        }

        public async Task<List<AdPlacementDetails>> GetAdPlacements()
        {
            return await _adPlacementService.InitAdPlacements();
        }
    }
}