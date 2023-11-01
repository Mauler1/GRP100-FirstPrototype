using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //movement vars
    private Rigidbody2D _rb;
    private float speed = 40f;
    private float _xMove;
    private float _yMove;

    //player status vars
    public static float health = 25;
    public static int damage = 5;


    // Start is called before the first frame update
    void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        CheckInput();
    }

    private void FixedUpdate(){

        

         _rb.AddForce(new Vector2(_xMove, _yMove) * speed);

    }

    void CheckInput(){

        _xMove = Input.GetAxis("Horizontal");
        _yMove = Input.GetAxis("Vertical");

    }
}
