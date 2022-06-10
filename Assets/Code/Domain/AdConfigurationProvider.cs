using System.Threading.Tasks;
using Domain;

namespace Submodules.UnityAdSystem.Assets.Code.Domain
{
    public interface IAdConfigurationProvider
    {
        AdConfiguration GetConfiguration();
    }
}