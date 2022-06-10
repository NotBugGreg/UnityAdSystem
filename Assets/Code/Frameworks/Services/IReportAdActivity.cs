using System.Threading.Tasks;
using PlayFab.ClientModels;

namespace Submodules.UnityAdSystem.Assets.Code.Main
{
    public interface IReportAdActivity
    {
        public void ReportingAdActivity(TaskCompletionSource<ReportAdActivityResult> taskCompletionSource);
    }
}