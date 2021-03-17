using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    Rigidbody2D player;

    public float upForce = 200f;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();
        player.gravityScale = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Controller.isOpen && Time.timeScale == 1 && Input.GetKeyDown("space"))
        {
            player.AddForce(new Vector2(0, upForce));
        }
    }
}
