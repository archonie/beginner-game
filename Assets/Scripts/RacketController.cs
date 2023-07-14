
using UnityEngine;

public class RacketController : MonoBehaviour
{
    public float playerSpeed = 10f;
    private Rigidbody rb;
    public FixedJoystick joystick;
    private bool freezed = false;
    private bool expended = false;
    private bool shrinked = false;
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
        if(freezed){
            return;
        }
        else{
            rb.velocity = joystick.Horizontal * playerSpeed * Vector3.right;
        }
        
    }
    
    public void freezePlayer(){
        rb.velocity = Vector3.zero; 
        this.freezed = true;
        Invoke("unFreeze", 2f);
    }
   
    public void unFreeze(){
        this.freezed = false;
    }
    public void speedUp(){
        this.playerSpeed = 20f;
        Invoke("speedDown", 3f);
    }
    public void speedDown(){
        this.playerSpeed = 10f;
    }
    public void Expand(){
        if(!expended){
            this.transform.localScale += new Vector3(0f, 0f, 0.3f);
            expended = true;
            Invoke("Normalize", 3f);
        }
    }
    public void Shrink(){
        if(!shrinked){
            this.transform.localScale -= new Vector3(0f, 0f, 0.3f);
            shrinked = true;
            Invoke("Normalize", 3f);
        }
    }
    public void Normalize(){
        if(shrinked){
            this.transform.localScale += new Vector3(0f,0f, 0.3f);
            shrinked = false;
        }
        if(expended){
            this.transform.localScale -= new Vector3(0f,0f, 0.3f);
            expended = false;
        }
    }
}
