using System.Threading.Tasks;
using Domain;
using Submodules.UnityAdSystem.Assets.Code.Basic_Implementation.Installers;
using Submodules.UnityAdSystem.Assets.Code.Domain;

namespace Submodules.UnityAdSystem.Assets.Code.InterfaceAdapters
{
    public class AdConfigurationProviderImpl : IAdConfigurationProvider
    {
        public AdConfiguration GetConfiguration()
        {
            return new AdConfiguration(PlayfabAdConfiguration.ONE_VIDEO_THREE_HINTS_UNIT_ID_TEST);
        }
    }
}