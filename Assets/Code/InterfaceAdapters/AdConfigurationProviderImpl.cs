using Submodules.UnityAdSystem.Assets.Code.Basic_Implementation.Installers;
using Submodules.UnityAdSystem.Assets.Code.Domain;

namespace Submodules.UnityAdSystem.Assets.Code.InterfaceAdapters
{
    public class AdConfigurationProviderImpl : IAdConfigurationProvider
    {
        private string _adID;
        
        public AdConfiguration GetConfiguration()
        {
            return new AdConfiguration(_adID);
        }

        public void SetAdId(string adID)
        {
            _adID = adID;
        }
    }
}