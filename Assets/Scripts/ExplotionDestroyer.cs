using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplotionDestroyer : MonoBehaviour
{
    float explotionTime = 1.4f;

    // Start is called before the first frame update
    void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        explotionTime -= Time.deltaTime;
        if (explotionTime <= 0)
        {   
            Destroy(gameObject);
        }
    }
}
