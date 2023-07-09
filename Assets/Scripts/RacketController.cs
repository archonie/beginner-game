using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public FixedJoystick joystick;
    public bool isPlayer = true;
    private Transform ball;
    public float offset = 1f;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ball = GameObject.FindGameObjectWithTag("Ball").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPlayer){
            MoveByPlayer();
        }
        else{
            MoveByComputer();
        }
    }
    void MoveByPlayer(){
        rb.velocity = joystick.Horizontal * speed * Vector3.right;
        transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
        
    }
    void MoveByComputer(){
        if(ball.position.x < transform.position.x + offset){
            rb.velocity = Vector3.left * speed;
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);


        }
        else if(ball.position.x > transform.position.x - offset){
            rb.velocity = Vector3.right * speed;
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);

        }
        else{
            rb.velocity = Vector3.zero;
            transform.position = new Vector3(transform.position.x, 0f, transform.position.z);
            
            
        }
        
    }
  
}
