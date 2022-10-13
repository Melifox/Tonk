using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{
<<<<<<< Updated upstream
    float bulletTtl = 5;

=======
    float bulletTtl = 4;
    [SerializeField]
    GameObject bulletExplosion;


    void start()
    {
    }
>>>>>>> Stashed changes
    // Update is called once per frame
    void Update()
    {
        bulletTtl -= Time.deltaTime;
        if (bulletTtl <= 0)
<<<<<<< Updated upstream
        {
=======
        {   
            Instantiate(bulletExplosion, transform.position, transform.rotation);
>>>>>>> Stashed changes
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
<<<<<<< Updated upstream
    {
=======
    {   
        //explosionPosition = GameObject.FindGameObjectWithTag("Bullet").Transform;
        GameObject e = Instantiate(bulletExplosion, transform.position, transform.rotation);
>>>>>>> Stashed changes
        Destroy(gameObject);
    }
}
