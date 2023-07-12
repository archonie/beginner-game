
using UnityEngine;

public class ComputerController : MonoBehaviour
{
    public float computerSpeed = 10f;
    private Rigidbody rb;
    private Transform ball;
    public float offset = 1f;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ball = GameObject.FindGameObjectWithTag("Ball").transform;
    }

    // Update is called once per frame
    void Update()
    {
        MoveByComputer();
        

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
    public void freezeComputer(){
        rb.velocity = Vector3.zero;
        this.rb = null;
        Invoke("unFreeze", 1.5f);       
    }
    public void unFreeze(){
        rb = GetComponent<Rigidbody>();
    }
    public void speedUp(){
        this.computerSpeed = 20f;
        Invoke("speedDown", 3f);
    }
    public void speedDown(){
        this.computerSpeed = 10f;
    }
}
