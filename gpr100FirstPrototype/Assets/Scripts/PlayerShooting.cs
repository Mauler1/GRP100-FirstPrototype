using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public float shotTime = 2;
    public bool shootAgain = true;
    public float timer;

    // Update is called once per frame
    void Update()
    {
        
        if(shootAgain && Input.GetButton("Fire1")){

            Shoot();
            shootAgain = false;
            timer = 0;

        }
        if (timer < shotTime){

            timer += Time.deltaTime;

            if(timer >= shotTime){

                shootAgain = true;

            }
        }

    }

    void Shoot(){
        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D _rb = bullet.GetComponent<Rigidbody2D>();
        _rb.AddForce(firePoint.up*bulletForce, ForceMode2D.Impulse);
    }
}
