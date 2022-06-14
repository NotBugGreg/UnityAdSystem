using Submodules.UnityAdSystem.Assets.Code.Domain.Services;

namespace Submodules.UnityAdSystem.Assets.Code.Domain
{
    public class ShowRewardedAdUseCase
    {
        private readonly IAdService _adService;

        public ShowRewardedAdUseCase(IAdService adService)
        {
            _adService = adService;
        }

        public void Show()
        {
            _adService.ShowRewardedAd();
        }
    }
}