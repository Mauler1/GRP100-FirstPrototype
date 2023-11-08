using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float health = 5;
    public sceneChange playerDeath;

    // Start is called before the first frame update

    void Update(){

        if(health <= 0){
            Console.WriteLine("dead");
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
       AiHealthAndDamage enemy = collision.GetComponent<AiHealthAndDamage>();
       if(enemy != null){
            health -= 1;
       }
    }
}
