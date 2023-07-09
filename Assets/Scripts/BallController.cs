using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{

    public float speed;
    private Vector3 direction;
    private Rigidbody rb;
    public float minDirection = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        this.rb = GetComponent<Rigidbody>();
        ChooseDirection();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }
    void FixedUpdate() {
        this.rb.MovePosition(this.rb.position + direction * speed * Time.fixedDeltaTime);
    }
    private void OnTriggerEnter(Collider other) {
        if(other.CompareTag("Wall")){
            direction.x = -direction.x;
            direction.y = 0f;
            
        }
        if(other.CompareTag("Racket")){
            Vector3 newDirection = (transform.position - other.transform.position).normalized;
            newDirection.z = Mathf.Sign(newDirection.z) * (Mathf.Max(Mathf.Abs(newDirection.z), this.minDirection));
            newDirection.x = Mathf.Sign(newDirection.x) * (Mathf.Max(Mathf.Abs(newDirection.x), this.minDirection));
            newDirection.y = 0f;
            direction = newDirection;
        }
    }
    private void ChooseDirection(){
        float signX = Mathf.Sign(Random.Range(-1f,1f));
        float signZ = Mathf.Sign(Random.Range(-1f,1f));
        this.direction = new Vector3(0.5f *signX , 0f, 0.5f*signZ);
    }
    // public void Stop() {
    //     stopped = true;
    // }

    // public void Go() {
    //     stopped = false;
    // }

}
