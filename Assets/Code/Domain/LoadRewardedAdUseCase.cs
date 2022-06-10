using Domain;

namespace Submodules.UnityAdSystem.Assets.Code.Domain
{
    public class LoadRewardedAdUseCase
    {
        private readonly IAdService _adService;

        public LoadRewardedAdUseCase(IAdService adService)
        {
            _adService = adService;
        }

        public void Load()
        {
            _adService.LoadRewardedAd();
        }

    }
}