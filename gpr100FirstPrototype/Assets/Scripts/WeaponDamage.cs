using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponDamage : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if(collision.gameObject.TryGetComponent<AiHealthAndDamage>(out AiHealthAndDamage enemyComponent)) 
        {
            enemyComponent.TakeHit(1);
        }
    }
}
