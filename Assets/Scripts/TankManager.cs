using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
    float moveSpeed = 5;
    [SerializeField]
    float jumpPower = 10;
    bool canJumpOrFire = false;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerTurn == true)
        {
            barrelRotator.RotateAround(Vector3.forward, Input.GetAxis("Vertical") * Time.deltaTime);

            if (Input.GetKey(KeyCode.A))
            {
                bulletPower -= 0.01f;
            }

            if (Input.GetKey(KeyCode.D))
            {
                bulletPower += 0.01f;
            }

            if (Input.GetKeyDown(KeyCode.Space) && canJumpOrFire == true)
            {
                GameObject b = Instantiate(BulletToFire, firePoint.position, firePoint.rotation);
                b.GetComponent<Rigidbody2D>().AddForce(barrelRotator.up * bulletPower, ForceMode2D.Impulse);
                Invoke("ChangeTurn", 0.1f);
            }
            
            transform.Translate(Vector2.right * moveSpeed * Time.deltaTime * Input.GetAxis("Horizontal"));
            if (Input.GetKeyDown(KeyCode.UpArrow) && canJumpOrFire== true)
            {
                rb.AddForce(Vector2.up * jumpPower, ForceMode2D.Impulse);
            }
        }    
    }

    void ChangeTurn()
    {
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
