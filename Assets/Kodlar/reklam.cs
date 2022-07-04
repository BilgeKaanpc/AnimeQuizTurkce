using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;


public class reklam : MonoBehaviour
{

    private BannerView bannerim;



    public string appId = "ca-app-pub-1056663813267203~9686446813";
    public string reklamId = "ca-app-pub-1056663813267203/5663796543";
    public AdPosition position;

    
    void Start()
    {


        bannerShow();

        MobileAds.Initialize(appId);
    }


  
    void Update()
    {
        
    }


    public void bannerShow()
    {
        bannerim = new BannerView(reklamId, AdSize.Banner, position);

        AdRequest yeniReklam = new AdRequest.Builder().Build();

        bannerim.LoadAd(yeniReklam);
        bannerim.Show();
    }
}
