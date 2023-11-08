using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiHealthAndDamage : MonoBehaviour
{
    
    public float Maxhealth = 3f;
    float health;
    public float damage = 1;
    public PlayerMovement playerMovement;

    private void OnTriggerEnter2D(Collider2D other) 
    {
        Debug.Log("Start doing damage");
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        Debug.Log("Stop doing damage");
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("Continue damage");
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        playerMovement.hp(1);
    }

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
        }
    }

}
