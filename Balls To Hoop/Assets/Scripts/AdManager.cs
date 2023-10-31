using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AdManager : MonoBehaviour
{
#if UNITY_ANDROID
        string appKey = "85460dcd";
#elif UNITY_IPHONE
    string appKey = "1c2ac2e15";   //"8545d445";
#else
        string appKey = "unexpected_platform";
#endif
    public static AdManager instance;

    private void Awake()
    {
        instance = this;
        InitializeAds();


    }


    public void InitializeAds()
    {
        IronSource.Agent.setConsent(true);
        IronSource.Agent.setMetaData("is_test_suite", "enable");//yayımlarken sil
        IronSource.Agent.init(appKey);
        IronSource.Agent.validateIntegration();
    }


    public void OdulluReklamYukle()
    {
        IronSource.Agent.loadRewardedVideo();
    }

    public void OdulluGoster()
    {
        if (IronSource.Agent.isRewardedVideoAvailable())
        {
            IronSource.Agent.showRewardedVideo();
        }
        else
        {
            print("Rewarded not ready !!");
            OdulluReklamYukle();
        }
            
    }


    public void SdkInitializationCompletedEvent()
    {
        Debug.Log("IronSource has been initialized with success");
        IronSource.Agent.launchTestSuite(); // yayımlarken sil

    }



    private void OnApplicationPause(bool pause)
    {
        IronSource.Agent.onApplicationPause(pause);
    }
    private void OnEnable()
    {
        IronSourceEvents.onSdkInitializationCompletedEvent += SdkInitializationCompletedEvent;


        IronSourceRewardedVideoEvents.onAdAvailableEvent += RewardedVideoOnAdAvailable;

        //Add AdInfo Rewarded Video Events
        IronSourceRewardedVideoEvents.onAdOpenedEvent += RewardedVideoOnAdOpenedEvent;
        IronSourceRewardedVideoEvents.onAdClosedEvent += RewardedVideoOnAdClosedEvent;
        IronSourceRewardedVideoEvents.onAdUnavailableEvent += RewardedVideoOnAdUnavailable;
        IronSourceRewardedVideoEvents.onAdShowFailedEvent += RewardedVideoOnAdShowFailedEvent;
        IronSourceRewardedVideoEvents.onAdRewardedEvent += RewardedVideoOnAdRewardedEvent;
        IronSourceRewardedVideoEvents.onAdClickedEvent += RewardedVideoOnAdClickedEvent;

    }
    //Add AdInfo Rewarded Video Events



    /************* RewardedVideo AdInfo Delegates *************/
    // Indicates that there’s an available ad.
    // The adInfo object includes information about the ad that was loaded successfully
    // This replaces the RewardedVideoAvailabilityChangedEvent(true) event
    void RewardedVideoOnAdAvailable(IronSourceAdInfo adInfo)
    {

    }
    // Indicates that no ads are available to be displayed
    // This replaces the RewardedVideoAvailabilityChangedEvent(false) event
    void RewardedVideoOnAdUnavailable()
    {
        Debug.Log("unavailable reklam");

    }
    // The Rewarded Video ad view has opened. Your activity will loose focus.
    void RewardedVideoOnAdOpenedEvent(IronSourceAdInfo adInfo)
    {


    }
    // The Rewarded Video ad view is about to be closed. Your activity will regain its focus.
    void RewardedVideoOnAdClosedEvent(IronSourceAdInfo adInfo)
    {


    }
    // The user completed to watch the video, and should be rewarded.
    // The placement parameter will include the reward data.
    // When using server-to-server callbacks, you may ignore this event and wait for the ironSource server callback.
    void RewardedVideoOnAdRewardedEvent(IronSourcePlacement placement, IronSourceAdInfo adInfo)
    {
        Debug.Log("ÖDÜLLÜ GÖRÜLDÜ VE ÖDÜL VERİLDİ");
        GameManager.instance.DevamEt(); //burada ödül olarak topu baslangıca attık.

    }
    // The rewarded video ad was failed to show.
    void RewardedVideoOnAdShowFailedEvent(IronSourceError error, IronSourceAdInfo adInfo)
    {

    }
    // Invoked when the video ad was clicked.
    // This callback is not supported by all networks, and we recommend using it only if
    // it’s supported by all networks you included in your build.
    void RewardedVideoOnAdClickedEvent(IronSourcePlacement placement, IronSourceAdInfo adInfo)
    {


    }
}
