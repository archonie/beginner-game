using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public float speed;
    private Vector3 direction;
    private Rigidbody rb;
    public float minDirection = 1f;
    private Vector3 startPosition;
    private bool stopped = false;
    private int flag = 0;
    public GameObject spawnManager;
    private SpawnManager sManager;
    public GameObject player;
    public GameObject computer;
    private RacketController playerController;
    private ComputerController computerController;
    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        this.startPosition = this.transform.position;
        this.sManager = this.spawnManager.GetComponent<SpawnManager>();
        this.playerController = this.player.GetComponent<RacketController>();
        this.computerController = this.computer.GetComponent<ComputerController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void FixedUpdate() {
        if(stopped){
            return;
        }
        this.rb.MovePosition(this.rb.position + direction * speed * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Wall")){
            direction.x = -direction.x;
            direction.y = 0f;
            
        }
        if(other.CompareTag("Computer")){
            Vector3 newDirection = (transform.position - other.transform.position).normalized;
            newDirection.z = Mathf.Sign(newDirection.z) * (Mathf.Max(Mathf.Abs(newDirection.z), this.minDirection));
            newDirection.x = Mathf.Sign(newDirection.x) * (Mathf.Max(Mathf.Abs(newDirection.x), this.minDirection));
            newDirection.y = 0f;
            direction = newDirection;
            flag = -1;  
        }
        if(other.CompareTag("Player")){
            Vector3 newDirection = (transform.position - other.transform.position).normalized;
            newDirection.z = Mathf.Sign(newDirection.z) * (Mathf.Max(Mathf.Abs(newDirection.z), this.minDirection));
            newDirection.x = Mathf.Sign(newDirection.x) * (Mathf.Max(Mathf.Abs(newDirection.x), this.minDirection));
            newDirection.y = 0f;
            direction = newDirection;
            flag = 1;
        }
        if(other.CompareTag("speedBall")){
                this.speed = this.speed * 1.2f;
                Invoke("speedDown", 3f);
                this.sManager.DestroyObject();
            }
        if(other.CompareTag("freeze")){
            if(flag == 1){
                this.sManager.DestroyObject();
                this.computerController.freezeComputer();
                
            }
            if(flag == -1){
                this.sManager.DestroyObject();
                this.playerController.freezePlayer();
            }

        }
        if(other.CompareTag("speedRacket")){
            if(flag == 1){
                this.playerController.speedUp();
                this.sManager.DestroyObject();
            }
            if(flag == -1){
                this.computerController.speedUp();
                this.sManager.DestroyObject();
            }
        }
    
    }
    private void ChooseDirection(){
        float signX = Mathf.Sign(Random.Range(-1f,1f));
        float signZ = Mathf.Sign(Random.Range(-1f,1f));
        this.direction = new Vector3(0.5f *signX , 0f, 0.5f*signZ);
    }
    public void Stop() {
        this.speed = 20f;
        stopped = true;
    }

    public void Go() {
        ChooseDirection();
        stopped = false;
        
    }
    public void ResetBall(){
        Stop();
        this.transform.position = startPosition;
        this.sManager.DestroyObject();
        this.computerController.unFreeze();
        this.playerController.unFreeze();
        this.playerController.speedDown();
        this.computerController.speedDown();
        Invoke("DelayResetBall", 1.3f);
    }
    public void DelayResetBall(){
        Go();
    }
    public void speedDown(){
        this.speed = 20f;
    }
}
