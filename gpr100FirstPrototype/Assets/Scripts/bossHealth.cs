using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bossHealth : MonoBehaviour
{
    public float Maxhealth = 5f;
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
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //playerMovement.hp(1);
    }

    private void Start()
    {
        health = Maxhealth;
    }

    public void TakeHit(float damage)
    {
        health -= damage;
        Debug.Log("Health = " + health);

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
