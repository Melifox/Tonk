using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ErrorShot : MonoBehaviour
{
    GameObject tank;
    int randomNumber;
    float TtL = 4f;
    [SerializeField]
    GameObject bulletExplosion;

    // Start is called before the first frame update
    void Start()
    {
        randomNumber = Random.Range(1, 10);
        Debug.Log(randomNumber);
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

        if (collision.gameObject.tag == "Player" && randomNumber == 5)
        {
            tank = GameObject.FindGameObjectWithTag("Player");
            tank.GetComponent<TankManager>().health -= 9999;
            GameObject e = Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag == "Player" && randomNumber != 5)
        {
            GameObject e = Instantiate(bulletExplosion, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }
}
