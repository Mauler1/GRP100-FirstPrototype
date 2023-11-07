using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    
    void OnCollisionEnter2D(Collision2D collision){

        Destroy(gameObject);

    }

}
