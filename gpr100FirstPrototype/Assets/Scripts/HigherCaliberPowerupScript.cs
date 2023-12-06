using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class HigherCaliberPowerupScript : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision){

        PlayerShooting player = collision.GetComponent<PlayerShooting>();
        if(player != null){
            Destroy(gameObject);
            player.addBullet();
        }

    }
}
