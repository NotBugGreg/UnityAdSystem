using System.Collections.Generic;
using System.Threading.Tasks;
using PlayFab.ClientModels;

namespace Submodules.UnityAdSystem.Assets.Code.Basic_Implementation.Installers
{
    public interface IAdPlacement
    {
        Task<List<AdPlacementDetails>> InitAdPlacements();
    }
}