using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public Transform firePoint;
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public float shotTime = 2;
    public float damage = 1;
    public int bulletNums = 1;
    public float bulletSpread = 0;
    public bool shootAgain = true;
    public float shotTimer;
    public float higherCaliberPowerupTimer = 0;

    // Update is called once per frame
    void Update()
    {
        //bonus shot powerup timer
        if(bulletNums > 1 && higherCaliberPowerupTimer < 45){
            higherCaliberPowerupTimer += Time.deltaTime;
        }

        if(higherCaliberPowerupTimer >= 45){
            higherCaliberPowerupTimer = 0;
            lessBullet();
        }
        //
        
        //time between shots timer
        if(shootAgain && Input.GetButton("Fire1")){

            Shoot();
            shootAgain = false;
            shotTimer = 0;

        }
        if (shotTimer < shotTime){

            shotTimer += Time.deltaTime;

            if(shotTimer >= shotTime){

                shootAgain = true;

            }
        }

    }
    public void shootSpeed(float adjust)
    {
        shotTime -= adjust;
    }
    public void shootDamage(float adjust)
    {
        damage += adjust;
    }

    public void addBullet(){
        bulletNums += 1;
        bulletSpread += 15;
    }

    public void lessBullet(){
        bulletNums -= 1;
        bulletSpread -= 15;
    }
    public float getDamage() 
    {
        return damage;
    }

    void Shoot(){
        //bullet rotation and spread values
        float spreadRot = bulletSpread/bulletNums;
        Vector3 spread = firePoint.rotation.eulerAngles;
        spread = new Vector3(spread.x, spread.y, spread.z - spreadRot);

        for(int i = 0; i < bulletNums; i++){
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.Euler(spread));
            Rigidbody2D _rb = bullet.GetComponent<Rigidbody2D>();
            _rb.AddForce(bullet.transform.up*bulletForce, ForceMode2D.Impulse);

            //bullet spread variability
            //spreadRot -= 15;
            spread = new Vector3(spread.x, spread.y, Random.Range(spread.z - spreadRot, spread.z + spreadRot));
        }
    }
}
