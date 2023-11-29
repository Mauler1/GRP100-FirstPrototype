using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public GameObject hitEffect;
    public int score;
    private void Start()
    {
        score = 0;
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
            enemy.TakeHit(2);
       }
       bossHealth boss = collision.GetComponent<bossHealth>();
       if (boss != null)
       {
            boss.TakeHit(2);
        }
       ShieldHpAndDamage shield = collision.GetComponent<ShieldHpAndDamage>();
       if (shield != null)
       {
            shield.TakeHit(2);
        }
    }

}
