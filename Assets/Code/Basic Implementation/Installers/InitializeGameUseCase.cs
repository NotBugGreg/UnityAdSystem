using System.Threading.Tasks;

namespace Submodules.UnityAdSystem.Assets.Code.Basic_Implementation.Installers
{
    public class InitializeGameUseCase : IGameInitializer
    {
        private readonly IAdPlacementRequester _adPlacementRequester;

        public InitializeGameUseCase(IAdPlacementRequester adRewardService)
        {
            _adPlacementRequester = adRewardService;
        }

        public async Task InitGameAsync()
        {
            await _adPlacementRequester.GetAdPlacements();
        }
    }
}