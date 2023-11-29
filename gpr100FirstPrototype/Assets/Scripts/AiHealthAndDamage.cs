using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiHealthAndDamage : MonoBehaviour
{
    
    public float Maxhealth = 3f;
    public float health;
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
            
            Destroy (gameObject);
            scoreChanger.scoreChange(1);
            Debug.Log("add score");
        }
    }

}
