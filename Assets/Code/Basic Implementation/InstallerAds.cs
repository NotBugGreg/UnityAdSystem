using System;
using System.Collections;
using System.Collections.Generic;
using Domain;
using UnityEngine;


using GoogleMobileAds.Api;
using UnityEngine.UI;

public class InstallerAds : MonoBehaviour
{

    private RewardedAd rewardedAd;
    private readonly string ONE_VIDEO_THREE_HINTS_UNIT_ID = "ca-app-pub-3009865580436574/8781940162";
    private readonly string ONE_VIDEO_THREE_HINTS_UNIT_ID_TEST = "ca-app-pub-3940256099942544/5224354917";
    public Button showRewardAdsButton;
    public void Start()
    {
        
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus =>
        { });

        RequestRewardedAd();
        ConfigureEvents();
        showRewardAdsButton.onClick.AddListener(UserChoseToWatchAd);
    }
    

    private void ConfigureEvents()
    {
        // Called when an ad request has successfully loaded.
        this.rewardedAd.OnAdLoaded += HandleRewardedAdLoaded;
        // Called when an ad request failed to load.
        this.rewardedAd.OnAdFailedToLoad += HandleRewardedAdFailedToLoad;
        // Called when an ad is shown.
        this.rewardedAd.OnAdOpening += HandleRewardedAdOpening;
        // Called when an ad request failed to show.
        this.rewardedAd.OnAdFailedToShow += HandleRewardedAdFailedToShow;
        // Called when the user should be rewarded for interacting with the ad.
        this.rewardedAd.OnUserEarnedReward += HandleUserEarnedReward;
        // Called when the ad is closed.
        this.rewardedAd.OnAdClosed += HandleRewardedAdClosed;

    }

    private void RequestRewardedAd()
    {
        this.rewardedAd = new RewardedAd(ONE_VIDEO_THREE_HINTS_UNIT_ID_TEST);

        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the rewarded ad with the request.
        this.rewardedAd.LoadAd(request);
    }
    
    private void HandleRewardedAdLoaded(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdLoaded event received");
    }

    private void HandleRewardedAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToLoad event received with message: "
            + args.LoadAdError.GetResponseInfo());
    }

    private void HandleRewardedAdOpening(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdOpening event received");
    }

    private void HandleRewardedAdFailedToShow(object sender, AdErrorEventArgs args)
    {
        MonoBehaviour.print(
            "HandleRewardedAdFailedToShow event received with message: "
            + args.Message);
    }

    private void HandleRewardedAdClosed(object sender, EventArgs args)
    {
        MonoBehaviour.print("HandleRewardedAdClosed event received");
    }

    public void HandleUserEarnedReward(object sender, Reward args)
    {
        string type = args.Type;
        double amount = args.Amount;
        MonoBehaviour.print(
            "HandleRewardedAdRewarded event received for "
            + amount.ToString() + " " + type);
    }
    
    private void UserChoseToWatchAd()
    {
        if (this.rewardedAd.IsLoaded()) {
            this.rewardedAd.Show();
        }
    }

}

