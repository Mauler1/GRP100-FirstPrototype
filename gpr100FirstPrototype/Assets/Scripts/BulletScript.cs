using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D collision){

        Destroy(gameObject);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       Destroy(gameObject);
       AiHealthAndDamage enemy = collision.GetComponent<AiHealthAndDamage>();
       if(enemy != null){
            enemy.TakeHit(1);
       }
    }

}
