using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Callbacks;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    //movement vars
    private Rigidbody2D _rb;
    Vector2 movement;
    Vector2 mousePos;
    public Camera cam;
    private float speed = 5f;

    //player status vars
    public float health = 3;
    public static int damage = 5;
    public sceneChange playerDeath;

    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
        if(health <= 0)
        {
            playerDeath.SwitchScene();
        }

        mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
    }

    private void FixedUpdate(){

        
         _rb.MovePosition(_rb.position + movement * speed * Time.fixedDeltaTime);

         Vector2 lookDir = mousePos - _rb.position;
         float angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg - 90f;

         _rb.rotation = angle;

    }

    void CheckInput(){

        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

    }
    public void hp(int damage)
    {
        health -= damage;
    }
}
