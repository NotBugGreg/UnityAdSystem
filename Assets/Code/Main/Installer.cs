using System.Linq;
using Domain;
using Frameworks.Services;
using Submodules.UnityAdSystem.Assets.Code.Basic_Implementation.Installers;
using Submodules.UnityAdSystem.Assets.Code.Domain;
using Submodules.UnityAdSystem.Assets.Code.Frameworks.Services;
using Submodules.UnityAdSystem.Assets.Code.InterfaceAdapters;
using UnityEngine;

namespace Submodules.UnityAdSystem.Assets.Code.Main
{
    public class Installer : MonoBehaviour
    {
        [SerializeField] private RewardedAddLoaderImpl _rewardedAddLoaderImpl;
        private ShowRewardedAdUseCase _showRewardedAdUseCase;
        private LoadRewardedAdUseCase _loadRewardedAdUseCase;
        private ReportAdActivityUseCase _reportAdActivityUseCase;
        private RewardAdActivityUseCase _rewardAdActivityUseCase;
        private DeliverRewardedAdUseCase _deliverRewardedAdUseCase;

        private async void Awake()
        {
            var adPlacementService = new PlayfabRewardAdsService(PlayfabAdConfiguration.APP_ID_AD,
                PlayfabAdConfiguration.NAME_ONE_VIDEO_THREE_HINTS_UNIT_ID);
            var initAdPlacementsUseCase = new InitAdPlacementsUseCase(adPlacementService);
            var placementsAds = await initAdPlacementsUseCase.GetAdPlacements();
            var adPlacementDetails = placementsAds.FirstOrDefault();


            var adStrategy = GetAdStrategy();
            var adServiceImpl = new AdServiceImpl(adStrategy);
            
            var reportAdActivityService = new PlayfabReportAdActivityService(adPlacementDetails.PlacementId, adPlacementDetails.RewardId);

            var playfabRewardActivityAdService =
                new PlayfabRewardActivityAdService(adPlacementDetails.PlacementId, adPlacementDetails.RewardId);


            var adConfigurationProviderImpl = new AdConfigurationProviderImpl();
            var initAdServiceUseCase = new InitAdServiceUseCase(adServiceImpl, adConfigurationProviderImpl);
            initAdServiceUseCase.Init();

            _reportAdActivityUseCase = new ReportAdActivityUseCase(reportAdActivityService);
            _rewardAdActivityUseCase = new RewardAdActivityUseCase(playfabRewardActivityAdService);

            _loadRewardedAdUseCase = new LoadRewardedAdUseCase(adServiceImpl);
            _showRewardedAdUseCase = new ShowRewardedAdUseCase(adServiceImpl);
            _deliverRewardedAdUseCase = new DeliverRewardedAdUseCase(adServiceImpl);
            
            _deliverRewardedAdUseCase.InitCallbackReward();
        }

        private IAdSDKAdapter GetAdStrategy()
        {
            return new GoogleAdStrategy();

#if USE_UNITY_SDK
            return new UnityAdStrategy();
#endif

            return new DefaultAdStrategy(_rewardedAddLoaderImpl);
        }

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                _loadRewardedAdUseCase.Load();
            }

            if (Input.GetKeyDown(KeyCode.W))
            {
                _showRewardedAdUseCase.Show();
            }
        }
    }
}