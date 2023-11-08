using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    public AiHealthAndDamage damage;
    void OnCollisionEnter2D(Collision2D collision){

        Destroy(gameObject);
        damage.TakeHit(1);

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
       // Destroy(gameObject);
    }

}
