
using UnityEngine;

public class RacketController : MonoBehaviour
{
    public float playerSpeed = 10f;
    public float computerSpeed = 10f;
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
        rb.velocity = joystick.Horizontal * playerSpeed * Vector3.right;
    }
    void MoveByComputer(){
        if(ball.position.x < transform.position.x + offset){
            rb.velocity = Vector3.left * computerSpeed;
        }
        else if(ball.position.x > transform.position.x - offset){
            rb.velocity = Vector3.right * computerSpeed;
        }
        else{
            rb.velocity = Vector3.zero;
        }
        
    }
  
}
