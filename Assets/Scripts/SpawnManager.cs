using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject[] prefabs;
    private bool spawned = false;
    private GameObject prefab;
    private GameObject powerUp;
    Vector3 position;

    // Start is called before the first frame update

    // Update is called once per frame
    public void Spawn(){
        if(!spawned){
            position = new Vector3(Random.Range(-5.99f,6f), 0f, Random.Range(-7.99f,8f));
            prefab = prefabs[Random.Range(0,prefabs.Length)];
            powerUp = Instantiate(prefab, position, prefab.transform.rotation );
            spawned = true;
        }
    }
    public void DestroyObject(){
        Destroy(powerUp);
        spawned = false;
    }
}
