using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class MainView : MonoBehaviour
{
    public string adUnitIdBottom = "ca-app-pub-3940256099942544/6300978111";
    public string adUnitIdPause = "ca-app-pub-3940256099942544/1033173712";

    private Text score;
    private Button btnPlay;
    private Button btnReset;
    private Button btnPause;

    private Rigidbody2D player;

    private BannerView bannerView;
    private InterstitialAd interstitial;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize(initStatus => { });
        RequestBanner();

        score = transform.Find("TextScore").GetComponent<Text>();

        btnPlay = transform.Find("ButtonPlay").GetComponent<Button>();
        btnPlay.onClick.AddListener(OnClickButtonPlay);
        btnPlay.gameObject.SetActive(true);

        btnReset = transform.Find("ButtonReset").GetComponent<Button>();
        btnReset.onClick.AddListener(OnClickButtonReset);
        btnReset.gameObject.SetActive(false);

        btnPause = transform.Find("ButtonPause").GetComponent<Button>();
        btnPause.onClick.AddListener(OnClickButtonPause);
        btnPause.gameObject.SetActive(false);

        player = GameObject.FindWithTag("Player").GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnDestroy()
    {
        if (bannerView != null)
        {
            bannerView.Destroy();
        }
        if (interstitial != null)
        {
            interstitial.Destroy();
        }
    }

    // 创建横幅广告
    private void RequestBanner() 
    {
        bannerView = new BannerView(adUnitIdBottom, AdSize.SmartBanner, AdPosition.Bottom);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);
    }

    // 创建插页式广告
    private void RequestInterstitial()
    {
        

        // Initialize an InterstitialAd.
        interstitial = new InterstitialAd(adUnitIdPause);
        // Called when an ad request has successfully loaded.
        //interstitial.OnAdLoaded += HandleOnAdLoaded;
        // Called when an ad request failed to load.
        interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        // Called when an ad is shown.
        //interstitial.OnAdOpening += HandleOnAdOpened;
        // Called when the ad is closed.

        interstitial.OnAdClosed += HandleOnInterstitialAdClosed;
        // Called when the ad click caused the user to leave the application.
        //interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;


        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the interstitial with the request.
        interstitial.LoadAd(request);
    }

    public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    {
        MonoBehaviour.print("HandleFailedToReceiveAd event received with message: "
                            + args.Message);
    }

    public void HandleOnInterstitialAdClosed(object sender, EventArgs args)
    {
        interstitial.Destroy();
    }

    void OnClickButtonPlay()
    {
        btnPlay.gameObject.SetActive(false);
        btnPause.gameObject.SetActive(true);

        Time.timeScale = 1;
        Controller.isOpen = true;
        player.gravityScale = 1;
    }

    void OnClickButtonReset()
    {
        // 初始化
        Time.timeScale = 1;
        player.gravityScale = 0;
        player.position = new Vector2(-1.5f, 0);

        GameObject.Find("SpawnPoint").SendMessage("DestroyAllCloneObject");

        Controller.score = 0;
        score.text = "Score:0";
        btnPlay.gameObject.SetActive(true);

        btnReset.gameObject.SetActive(false);
    }

    void OnClickButtonPause()
    {
        if (Time.timeScale == 1)
        {
            Time.timeScale = 0;

            RequestInterstitial();
            if (interstitial.IsLoaded())
            {
                interstitial.Show();
            }
        }
        else if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
}
