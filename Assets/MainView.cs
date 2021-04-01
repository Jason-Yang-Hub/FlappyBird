using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using GoogleMobileAds.Api;

public class MainView : MonoBehaviour
{
    private Text score;
    private Button btnPlay;
    private Button btnReset;
    private Button btnPause;

    private Rigidbody2D player;

    // Start is called before the first frame update
    void Start()
    {
        MobileAds.Initialize(initStatus => { });

        string adUnitId = "ca-app-pub-3940256099942544/6300978111";

        BannerView bannerView = new BannerView(adUnitId, AdSize.Banner, AdPosition.Bottom);
        // Create an empty ad request.
        AdRequest request = new AdRequest.Builder().Build();
        // Load the banner with the request.
        bannerView.LoadAd(request);

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
        // ≥ı ºªØ
        Time.timeScale = 1;
        player.gravityScale = 0;
        player.position = new Vector2(-3, 0);

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
        }
        else if(Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }
}
