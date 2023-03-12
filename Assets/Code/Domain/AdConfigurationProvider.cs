namespace Submodules.UnityAdSystem.Assets.Code.Domain
{
    public interface IAdConfigurationProvider
    {
        AdConfiguration GetConfiguration();
        void SetAdId(string adID);

    }
}