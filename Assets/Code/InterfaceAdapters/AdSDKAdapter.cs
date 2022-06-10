using System;

namespace Submodules.UnityAdSystem.Assets.Code.InterfaceAdapters
{
    public interface IAdSDKAdapter
    {
        void ShowRewardedAd();
        void LoadRewardedAd();
        void SetCallbackRewardedAd(Action<RewardedAdStatusInterfaceAdapter> callback);

        void Init(AdConf configuration);
    }
}