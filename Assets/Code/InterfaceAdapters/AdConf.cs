using System;
using System.Collections.Generic;

namespace Submodules.UnityAdSystem.Assets.Code.InterfaceAdapters
{
    public class AdConf
    {
        public readonly string RewardAdId;
        public string GameId { get; set; }
        public bool TestMode { get; set; }
        public List<string> TestDevices { get; set; }
        
        public AdConf(string rewardAdId)
        {
            RewardAdId = rewardAdId;
        }

    }
}