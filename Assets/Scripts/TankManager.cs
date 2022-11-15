using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TankManager : MonoBehaviour
{
    public int playerNumber;
    bool playerTurn = false;
    [SerializeField]
    float bulletPower;
    [SerializeField]
    Transform barrelRotator;
    [SerializeField]
    Transform firePoint;
    [SerializeField]
    GameObject BulletToFire;
    Rigidbody2D rb;
    [SerializeField]
    float moveSpeed = 4;
    [SerializeField]
    float jumpPower = 10;
    public bool canJumpOrFire = false;
    [SerializeField]
    float fuel = 20;
    [SerializeField]
    public int health = 500;
    [SerializeField]
    Text healthUI;
    [SerializeField]
    Text powerUI;
    int percentagePower;
    [SerializeField]
    Text fuelUI;
    [SerializeField]
    Text bulletUI;
    [SerializeField]
    GameObject[] bullets;
    int bulletSelected = 0;




    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        percentagePower = Mathf.RoundToInt(bulletPower * 10.0f);
        healthUI.text = health.ToString();
        powerUI.text = percentagePower.ToString() + "%";
        fuelUI.text = Mathf.RoundToInt(fuel * 5f).ToString() + "%";
        bulletUI.text = bullets[bulletSelected].name;


        if (playerTurn == true)
        {
            barrelRotator.RotateAround(Vector3.forward, Input.GetAxis("Vertical") * Time.deltaTime);

            if (Input.GetKeyDown(KeyCode.C) && bulletSelected < bullets.Length - 1)
            {
                bulletSelected++;
                Debug.Log(bullets[bulletSelected]);
                BulletToFire = bullets[bulletSelected];
            }
            else if (Input.GetKeyDown(KeyCode.C))
            {
                bulletSelected = 0;
                Debug.Log(bullets[bulletSelected]);
                BulletToFire = bullets[bulletSelected];
            }

            if (Input.GetKey(KeyCode.S))
            {
                bulletPower -= 0.005f;
            }

            if (Input.GetKey(KeyCode.W))
            {
                bulletPower += 0.005f;
            }

            if (Input.GetButtonDown("Fire1") && canJumpOrFire == true)
            {
                GameObject b = Instantiate(BulletToFire, firePoint.position, firePoint.rotation);
                b.GetComponent<Rigidbody2D>().AddForce(barrelRotator.up * bulletPower, ForceMode2D.Impulse);
                Invoke("ChangeTurn", 0.1f);
            }
            if (fuel >= 0)
            {
                transform.Translate(Vector2.right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
                if (Input.GetAxis("Horizontal") != 0)
                {
                    fuel -= 0.05f;
                }
            }

            if (Input.GetButtonDown("Jump") && canJumpOrFire== true)
            {
                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
                
            }

            if (health <= 0)
            {
                GameObject.Find("GameManager").GetComponent<TurnManager>().bothPlayersAlive = false;
                Destroy(gameObject);
            }

            if (Input.GetKey("k"))
            {
                health = -10;
            }
        }    
    }

    /*void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            health -= 50;
        }
    }
    */

    void ChangeTurn()
    {
        fuel = 20f;
        GameObject.Find("GameManager").GetComponent<TurnManager>().ChangeTurn();
    }

    public void SetActive(bool b)
    {
        if (b == true)
        {
            playerTurn = true;
        }
        else
        {
            playerTurn = false;
        }
    }
}
