using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using GoogleMobileAds.Api;
using UnityEngine.Advertisements;
using Random = UnityEngine.Random;
using UnityEngine.UI;


public class ADGenerator : MonoBehaviour
{

    public static ADGenerator Instance;
    private UnityAds unityAds;
    private ADMobAds adMobAds;
    private ADGenerator adGenerator;
    private GameObject adManager;
    // Start is called before the first frame update

    void Start()
    {
        InitializeAds();
        Instance = this;
        adManager = GameObject.FindGameObjectWithTag("AdManager");
        unityAds = adManager.GetComponent<UnityAds>();
        adMobAds = adManager.GetComponent<ADMobAds>();
        adGenerator = adManager.GetComponent<ADGenerator>();

        
        if (Random.Range(0, 10) > 4)
        {
            // show unity banner
            unityAds.PlayBannerAd();
            Debug.Log("Showing Unity Banner Advertisement");
        }
        else 
        {
            adMobAds.ShowBannerAd();
            Debug.Log("Show ADMob Banner Advertisment");
        }
    }

    public void generateInterstitial()
    {
       
        if (Random.Range(0, 10) > 4)
        {
            UnityAds.Instance.DisplayInterstitialAD();
            Debug.Log("Showing Unity InTerstitial Advertisement");
        }
        else 
        {
            ADMobAds.Instance.RequestInterstitial();
            Debug.Log("Showing ADMob InTerstitial Advertisement");
        }
    }
    public void generateRewardVideo()
    {
       
        if (Random.Range(0, 10) > 4)
        {
            UnityAds.Instance.ShowRewardedVideo();

            Debug.Log("Showing Unity Reward Video");
        }
        else 
        {
            ADMobAds.Instance.RequestRewardBasedVideo();
            Debug.Log("Showing ADMob Reward Video");
            
        }
    }
    private void InitializeAds()
    {
        adMobAds = new ADMobAds();
        unityAds = new UnityAds();

    }
  
}
