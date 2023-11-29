using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject hitEffect;
    public PlayerShooting damageGet;
    public float damage = 1;
    void start()
    {
        damage = damageGet.getDamage();
    }
    void update()
    {
        damage = damageGet.getDamage();
    }
    void OnCollisionEnter2D(Collision2D collision){

        Destroy(gameObject);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       Destroy(gameObject);
        GameObject effect = Instantiate(hitEffect, transform.position, Quaternion.identity);
        Destroy(effect, 0.5f);
        AiHealthAndDamage enemy = collision.GetComponent<AiHealthAndDamage>();
       if(enemy != null){
            enemy.TakeHit(damage);
       }
       bossHealth boss = collision.GetComponent<bossHealth>();
       if (boss != null)
       {
            boss.TakeHit(damage);
        }
       ShieldHpAndDamage shield = collision.GetComponent<ShieldHpAndDamage>();
       if (shield != null)
       {
            shield.TakeHit(damage);
        }
        BoomeyHealth boom = collision.GetComponent<BoomeyHealth>();
        if(boom != null)
        {
            boom.TakeHit(damage);
        }
    }

}
