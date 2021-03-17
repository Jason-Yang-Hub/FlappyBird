using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Hitted : MonoBehaviour
{
    private Text deadNum;
    private Text scoreMax;

    // Start is called before the first frame update
    void Start()
    {
        deadNum = GameObject.Find("TextDeadNum").GetComponent<Text>();
        scoreMax = GameObject.Find("TextScoreMax").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (Controller.isOpen && collision.gameObject.tag == "Player")
        {
            Controller.isOpen = false;
            Controller.deadNum += 1;
            deadNum.text = "DeadTimes:" + Controller.deadNum;

            if (Controller.score > Controller.scoreMax)
            {
                Controller.scoreMax = Controller.score;
                scoreMax.text = "ScoreMax:" + Controller.scoreMax;
            }

            GameObject btnReset = GameObject.Find("MainView").transform.Find("ButtonReset").gameObject;
            btnReset.SetActive(true);
            GameObject btnPause = GameObject.Find("MainView").transform.Find("ButtonPause").gameObject;
            btnPause.SetActive(false);
        }
    }

}
