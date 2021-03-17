using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Colum : MonoBehaviour
{
    public float speed = 2.0f;

    private Text score;


    // Start is called before the first frame update
    void Start()
    {
        score = GameObject.Find("TextScore").GetComponent<Text>();
        Destroy(gameObject, 15f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Controller.isOpen) 
        {
            transform.Translate(Vector3.left * speed * Time.deltaTime);
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
