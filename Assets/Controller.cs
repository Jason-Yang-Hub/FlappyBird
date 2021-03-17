using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour
{
    public static int score = 0;
    public static int scoreMax = 0;
    public static int deadNum = 0;
    public static bool isOpen = false;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        scoreMax = 0;
        deadNum = 0;
        isOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
