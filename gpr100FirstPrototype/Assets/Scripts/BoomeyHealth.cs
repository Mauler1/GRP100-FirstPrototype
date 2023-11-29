using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
//boomey's mission is to kill elon musk
public class BoomeyHealth : MonoBehaviour
{
    public float Maxhealth = 3f;
    public float health;
    public float BoomRange = 300;
    public timer scoreChanger;


    private void Start()
    {
        health = Maxhealth;
    }

    public void TakeHit(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            scoreChanger.scoreChange(1);
            var hitColliders = Physics2D.OverlapCircleAll(transform.position, BoomRange);
            foreach (var hitCollider in hitColliders) 
            {
                AiHealthAndDamage enemy = hitCollider.GetComponent<AiHealthAndDamage>();
                if (enemy != null) 
                {
                    enemy.TakeHit(10);
                }
                bossHealth boss = hitCollider.GetComponent<bossHealth>();
                if (boss != null)
                {
                    boss.TakeHit(4);
                }
                ShieldHpAndDamage shield = hitCollider.GetComponent<ShieldHpAndDamage>();
                if (shield != null)
                {
                    shield.TakeHit(4);
                }
                PlayerHealth player = hitCollider.GetComponent<PlayerHealth>();
                if (player != null)
                {
                    player.takeHit(1);
                }
                Destroy(gameObject);
            }
        }
    }
}
