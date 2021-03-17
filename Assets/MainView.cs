using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainView : MonoBehaviour
{
    private Button btnPlay;
    private Text score;


    // Start is called before the first frame update
    void Start()
    {
        btnPlay = GameObject.Find("ButtonPlay").GetComponent<Button>();
        btnPlay.onClick.AddListener(OnClickButtonPlay);

        score = GameObject.Find("TextScore").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnClickButtonPlay()
    {
        Controller.score = 0;
        score.text = "Score:0";

        Controller.isOpen = true;
        btnPlay.gameObject.SetActive(false);
    }
}
