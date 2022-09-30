using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    float bulletTtl = 5;

    // Update is called once per frame
    void Update()
    {
        bulletTtl -= Time.deltaTime;
        if (bulletTtl <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
