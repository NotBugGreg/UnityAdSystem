using System;

namespace Submodules.UnityAdSystem.Assets.Code.Domain.Services
{
    public interface IAdService
    {
        void SetStatusRewardedAdCallback();

        void SetObserver(Action <RewardedAdStatus> callback);
        void ShowRewardedAd();
        void LoadRewardedAd();
        void Init(AdConfiguration adConfiguration);
    }
}