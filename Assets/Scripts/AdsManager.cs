using UnityEngine;
using System.Collections;
using Prime31;

public class AdsManager : MonoBehaviour {

	public string flurryAppId;
	public string adsSpaceBanner;
	public string adsSpaceFullScreen;

	public string AdColonyAppId;
	public string AdColonyZoneId;

	// Use this for initialization
	void Start () {


		// Flurry Ads
		FlurryAnalytics.startSession (flurryAppId, true);
		FlurryAds.fetchAdsForSpace (adsSpaceBanner, FlurryAdPlacement.BannerBottom);
		FlurryAds.fetchAdsForSpace (adsSpaceFullScreen, FlurryAdPlacement.FullScreen);

		// AdColony Ads

		AdColony.OnVideoStarted = this.OnVideoStarted;
		AdColony.OnVideoFinished = this.OnVideoFinished;
		AdColony.OnAdAvailabilityChange = this.OnAdAvailabilityChange;
		AdColony.OnV4VCResult = this.OnV4VCResult;

		AdColony.Configure
		(
			"version:1.0,store:google",
			AdColonyAppId,  // app id
			AdColonyZoneId // zone id
		);
	
	}

	// For Flurry Ads
	void ShowBanner() {

		FlurryAds.displayAd(adsSpaceBanner, FlurryAdPlacement.BannerBottom, 1000);
	}

	void ShowFullScreen(){
	
		FlurryAds.displayAd(adsSpaceFullScreen, FlurryAdPlacement.FullScreen, 1000);
	}


	public void PlayAVideo(string zoneID)
	{
		if (AdColony.IsVideoAvailable(zoneID))
		{
			Debug.Log("Play a video");
			AdColony.ShowVideoAd(zoneID);
		}
		else
		{
			Debug.Log("Video not avaiable");
		}
		
	}
	// for AdColony Ads
	public void OnVideoStarted()
	{
	}
	
	public void OnVideoFinished( bool ad_was_show)
	{
		Debug.Log ("OnVideofinished");
	}
	
	public void OnV4VCResult(bool success, string name, int amount)
	{
	}
	
	public void OnAdAvailabilityChange( bool avail, string zoneId)
	{
	}

}
