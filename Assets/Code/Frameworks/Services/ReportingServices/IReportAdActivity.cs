using System.Threading.Tasks;
using PlayFab.ClientModels;

namespace Submodules.UnityAdSystem.Assets.Code.Frameworks.Services.ReportingServices
{
    public interface IReportAdActivity
    {
        Task<ReportAdActivityResult> InitAdReporting();
    }
}