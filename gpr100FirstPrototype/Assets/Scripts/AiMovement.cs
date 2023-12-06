using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiMovement : MonoBehaviour
{
    public GameObject player;
    public float speed;
    int fix = 90;
    private float distance;
    private Vector3 testName = new Vector3(0f, 0f, 0f);

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        

        transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        transform.rotation = Quaternion.Euler(Vector3.forward * angle);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("teleporter"))
        {
            gameObject.transform.position = testName;
        }
    }
    void CheckPosition() 
    { 
    
    }
}
