using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colum : MonoBehaviour
{
    public float speed = 2.0f;

    private float liveTime = 15.0f;
    private float createTime = 0f;
    private Text score;


    // Start is called before the first frame update
    void Start()
    {
        createTime = Time.time;
        score = GameObject.Find("TextScore").GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Controller.isOpen) 
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);

            if (Time.time - createTime >= liveTime)
            {
                Destroy(gameObject);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Controller.score += 1;
            score.text = "Score:" + Controller.score;
        }
    }

    
}
