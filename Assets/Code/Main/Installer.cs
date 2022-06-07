using System;
using Domain;
using Frameworks.Services;
using Frameworks.View;
using InterfaceAdapters;
using Submodules.UnityAdSystem.Assets.Code.Domain;
using Submodules.UnityAdSystem.Assets.Code.Frameworks.Services;
using UnityEngine;

namespace Main
{
    public class Installer : MonoBehaviour
    {
        [SerializeField] private RewardedAddLoaderImpl _rewardedAddLoaderImpl;
        private ShowRewardedAdUseCase _showRewardedAdUseCase;
        private LoadRewardedAdUseCase _loadRewardedAdUseCase;

        private void Awake()
        {
            var adStrategy = GetAdStrategy();
            var adServiceImpl = new AdServiceImpl(adStrategy);

            var adConfigurationProviderImpl = new AdConfigurationProviderImpl();
            var initAdServiceUseCase = new InitAdServiceUseCase(adServiceImpl, adConfigurationProviderImpl);
            initAdServiceUseCase.Init();
            _loadRewardedAdUseCase = new LoadRewardedAdUseCase(adServiceImpl);
            _showRewardedAdUseCase = new ShowRewardedAdUseCase(adServiceImpl);
        }

        private AdSDKAdapter GetAdStrategy()
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