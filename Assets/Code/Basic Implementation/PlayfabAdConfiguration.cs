namespace Submodules.UnityAdSystem.Assets.Code.Basic_Implementation
{
    public class PlayfabAdConfiguration
    {

        public static readonly string APP_ID_AD = "ca-app-pub-3009865580436574~3542055920";//This is what matters to admob

#if UNITY_EDITOR
        public static readonly string ONE_VIDEO_THREE_HINTS_UNIT_ID_TEST = "ONE_VIDEO_THREE_HINTS_UNIT_ID_TEST";
        public static readonly string NAME_ONE_VIDEO_THREE_HINTS_UNIT_ID_TEST  = "ca-app-pub-3940256099942544/5224354917"; //for playfab
#else
        public static readonly string AD_ID = "ca-app-pub-3009865580436574/8781940162";
        public static readonly string REWARD_ID = "SOLITAIRE_HINT_REWARD";
#endif
    }
}