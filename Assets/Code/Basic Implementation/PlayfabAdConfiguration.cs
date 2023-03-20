namespace Submodules.UnityAdSystem.Assets.Code.Basic_Implementation
{
    public class PlayfabAdConfiguration
    {

        public static readonly string ADMOB_APP_ID = "ca-app-pub-3009865580436574~3542055920";//This is what matters to admob

#if UNITY_EDITOR
        public static readonly string AD_ID = "AdmobDoesntMind";
        public static readonly string REWARD_ID = "EDITOR_SOLITAIRE_HINT_REWARD"; //for playfab
#else
        public static readonly string AD_ID = "ca-app-pub-3009865580436574/8781940162";
        public static readonly string REWARD_ID = "SOLITAIRE_HINT_REWARD";
#endif
    }
}