namespace Submodules.UnityAdSystem.Assets.Code.Domain
{
    public class DeliverRewardedAdUseCase
    {
        private IAdService _adService;

        public DeliverRewardedAdUseCase(IAdService adService)
        {
            _adService = adService;
        }

        public async void InitCallbackReward()
        {
            var result = await _adService.DeliverRewardedAd();
            if (result == RewardedAdStatus.Ok)
            {
                //hacer esto por cada use case
                //para show y load pasar servicio reporting
                //para deliver, además pasar RewardActivityService
                //controlar estado en donde va bien y cuando falla
                // TODO: Dar la recompensa use case
                // TODO: Y reportar el estado
                return;
            }
            
            // TODO: Mostar mensaje de error use case
        }
    }
}