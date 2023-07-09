using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketController : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public FixedJoystick joystick;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move(){
        rb.velocity = joystick.Horizontal * speed * Vector3.right;
        
    }
  
}
