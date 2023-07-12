
using UnityEngine;

public class RacketController : MonoBehaviour
{
    public float playerSpeed = 10f;
    private Rigidbody rb;
    public FixedJoystick joystick;
    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveByPlayer();    
    }
    void MoveByPlayer(){
        rb.velocity = joystick.Horizontal * playerSpeed * Vector3.right;
    }
    
    public void freezePlayer(){
        rb.velocity = Vector3.zero;
        this.rb = null;
        Invoke("unFreeze", 1.5f);
    }
   
    public void unFreeze(){
        this.rb = GetComponent<Rigidbody>();
    }
    public void speedUp(){
        this.playerSpeed = 20f;
        Invoke("speedDown", 3f);
    }
    public void speedDown(){
        this.playerSpeed = 10f;
    }
}
