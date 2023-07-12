using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public float speed;
    private Vector3 direction;
    private Rigidbody rb;
    public float minDirection = 0.7f;

    private bool stopped = false;
    private int flag = 0;
    public GameObject spawnManager;
    private SpawnManager sManager;
    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        this.sManager = this.spawnManager.GetComponent<SpawnManager>();
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
        if(other.CompareTag("speed")){

            if(flag == 1){
                this.speed = this.speed * 1.2f;
                Debug.Log("Player speed up");
                this.sManager.DestroyObject();
            }
            if(flag == -1){   
                this.speed = this.speed * 1.2f;
                Debug.Log("Computer speed up");
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

}
