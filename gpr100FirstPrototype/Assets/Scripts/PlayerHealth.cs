using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 10;
    public sceneChange playerDeath;

    // Start is called before the first frame update

    void Update(){

        if(health <= 0){
            playerDeath.SwitchScene();
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       AiHealthAndDamage enemy = collision.GetComponent<AiHealthAndDamage>();
       if(enemy != null){
            health -= 1;
            Destroy(enemy.gameObject);
       }
    }
    public float getHealth()
    {
           return health;
    }
}
