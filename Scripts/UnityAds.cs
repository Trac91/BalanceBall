using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;
using GoogleMobileAds.Api;


public class UnityAds : MonoBehaviour, IUnityAdsListener
{
    // Start is called before the first frame update

    string GooglePlay_ID = "4060769";
    string rewardvideo_ID = "rewardedVideo";
    public string banner_ID = "bannerPlacement";
    public string Interstitial_ID = "interstitialAd";
    bool GameMode = true;
    
    public static UnityAds Instance;
    void Start()
    {
        Advertisement.AddListener(this);
        Advertisement.Initialize(GooglePlay_ID, GameMode);
        Instance = this;
    }
    IEnumerator ShowBannerWhenInitialized()
    {
        while (!Advertisement.isInitialized)
        {
            yield return new WaitForSeconds(0.5f);
        }
        Advertisement.Banner.SetPosition(BannerPosition.TOP_CENTER);
        Advertisement.Banner.Show(banner_ID);
    }

    public void DisplayInterstitialAD()
    {
        if (Advertisement.IsReady(Interstitial_ID))
        {
            Advertisement.Show(Interstitial_ID);
        }
        else
        {
            Debug.Log("Interstitial ad not ready");
        }
        //ADMobAds.Instance.RequestInterstitial();
        //addmob should be here

    }
    public void ShowRewardedVideo()
    {
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady(rewardvideo_ID))
        {
            Advertisement.Show(rewardvideo_ID);
        }
        else
        {
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
        }
       // ADMobAds.Instance.RequestRewardBasedVideo();
    }

    public void PlayBannerAd()
    {
        StartCoroutine(ShowBannerWhenInitialized());
    }

    public void RemoveBanner()
    {
        if (Advertisement.Banner.isLoaded)
        {
            Advertisement.Banner.Hide();
        }
        
    }
    public void OnUnityAdsDidFinish(string mySurfacingId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            Debug.LogWarning("You got a reward.");
        }
        else if (showResult == ShowResult.Skipped)
        {
            Debug.LogWarning("You do NOT got a reward.");
        }
        else if (showResult == ShowResult.Failed)
        {
            Debug.LogWarning("The ad did not finish due to an error.");
        }
    }
    public void OnUnityAdsReady(string surfacingId)
    {
        // If the ready Ad Unit or legacy Placement is rewarded, show the ad:
        if (surfacingId == rewardvideo_ID)
        {
            // Optional actions to take when theAd Unit or legacy Placement becomes ready (for example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        Debug.Log(message);
    }

    public void OnUnityAdsDidStart(string surfacingId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);

    }
}
