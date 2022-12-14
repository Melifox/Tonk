using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LuckyShot : MonoBehaviour
{
    GameObject tank;
    float TtL = 4f;
    [SerializeField]
    GameObject bulletExplosion;
    int randomDamage;

    // Start is called before the first frame update
    void Start()
    {
        randomDamage = Random.Range(1, 100);
    }

    // Update is called once per frame
    void Update()
    {
        TtL -= Time.deltaTime;
        if (TtL <= 0)
        {
            Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        { 
        GameObject e = Instantiate(bulletExplosion, transform.position, transform.rotation);
        Destroy(gameObject);
        }

        if (collision.gameObject.tag == "Player")
        {
            tank = GameObject.FindGameObjectWithTag("Player");
            tank.GetComponent<TankManager>().health -= randomDamage;
            GameObject e = Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
