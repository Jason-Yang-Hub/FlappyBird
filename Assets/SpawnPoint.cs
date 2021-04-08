using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public GameObject colum;

    public float coldDown = 3f;

    float nextTime = 0f;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Controller.isOpen && Time.time >= nextTime)
        {
            nextTime = Time.time + coldDown;

            Vector3 p = transform.position;
            p.y = Random.Range(-3f, 2f);

            Instantiate(colum, p,transform.rotation,transform);
        }
        
    }

    void DestroyAllCloneObject()
    {
        int count = transform.childCount;

        for (int i = 0; i < count; i++)
        {
            Destroy(transform.GetChild(i).gameObject);
        }
    }
}
