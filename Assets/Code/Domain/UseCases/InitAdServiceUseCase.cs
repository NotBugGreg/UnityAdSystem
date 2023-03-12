using Submodules.UnityAdSystem.Assets.Code.Domain.Services;

namespace Submodules.UnityAdSystem.Assets.Code.Domain
{
    public class InitAdServiceUseCase
    {
        private readonly IAdService _adService;
        private readonly IAdConfigurationProvider _adConfigurationProvider;

        public InitAdServiceUseCase(IAdService adService,
            IAdConfigurationProvider adConfigurationProvider)
        {
            _adService = adService;
            _adConfigurationProvider = adConfigurationProvider;
        }

        public void Init()
        {
            var configuration = _adConfigurationProvider.GetConfiguration();
            _adService.Init(configuration);
        }
    }
}