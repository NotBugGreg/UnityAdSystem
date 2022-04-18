using System.Threading.Tasks;

namespace Submodules.UnityAdSystem.Assets.Code.Basic_Implementation.Installers
{
    public interface IAdPlacementRequester
    {
        Task GetAdPlacements();
    }
}