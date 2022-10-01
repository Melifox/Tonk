using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    float bulletTtl = 1;
    [SerializeField]
    GameObject bulletExplosion;
    Transform explosionPosition;

    // Update is called once per frame
    void Update()
    {
        explosionPosition = GameObject.FindGameObjectWithTag("Bullet").transform;
        bulletTtl -= Time.deltaTime;
        if (bulletTtl <= 0)
        {
            GameObject e = Instantiate(bulletExplosion, explosionPosition);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject e = Instantiate(bulletExplosion, explosionPosition);
        Destroy(gameObject);
    }
}
