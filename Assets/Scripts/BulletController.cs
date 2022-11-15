using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
    float bulletTtl = 4;
    [SerializeField]
    GameObject bulletExplosion;
    GameObject tank;


    void start()
    {

    }
    // Update is called once per frame
    void Update()
    {
        bulletTtl -= Time.deltaTime;
        if (bulletTtl <= 0)
        {   
            Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //explosionPosition = GameObject.FindGameObjectWithTag("Bullet").Transform;
        GameObject e = Instantiate(bulletExplosion, transform.position, transform.rotation);
        Destroy(gameObject);

        if (collision.gameObject.tag == "Player")
        {
            tank = GameObject.FindGameObjectWithTag("Player");
            tank.GetComponent<TankManager>().health -= 50;
        }
    }
}