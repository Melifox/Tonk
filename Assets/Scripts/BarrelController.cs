using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BarrelController : MonoBehaviour
{
    [SerializeField]
    float bulletPower;
    [SerializeField]
    Transform barrelRotator;
    [SerializeField]
    Transform firePoint;
    [SerializeField]
    GameObject BulletToFire;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        barrelRotator.RotateAround(Vector3.forward, Input.GetAxis("Vertical") * Time.deltaTime);

        if (Input.GetKey(KeyCode.S))
        {
            bulletPower -= 0.01f;
        }

        if (Input.GetKey(KeyCode.W))
        {
            bulletPower += 0.01f;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject b = Instantiate(BulletToFire, firePoint.position, firePoint.rotation);
            b.GetComponent<Rigidbody2D>().AddForce(barrelRotator.up * bulletPower, ForceMode2D.Impulse);
        }
    }
}
