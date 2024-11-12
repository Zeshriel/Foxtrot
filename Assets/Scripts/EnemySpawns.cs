using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawns : MonoBehaviour
{
    public GameObject projectile1;
    public GameObject projectile2;
    float rand;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collider){
        GameObject otherGO = collider.gameObject;
        rand = Random.Range(0,10);

        if(rand > 5){
            GameObject newBolt = projectile1;
            Instantiate(newBolt, new Vector3(Random.Range(-2.0f,2.3f), transform.position.y + Random.Range(9,11), 0), newBolt.transform.rotation);
        }
        else{
            GameObject newBolt = projectile1;
            GameObject newBoom = projectile2;
            Instantiate(newBolt, new Vector3(Random.Range(-2.0f,0.0f), transform.position.y + Random.Range(9,11), 0), newBolt.transform.rotation);
            Instantiate(newBoom, new Vector3(Random.Range(-2.0f,2.5f), transform.position.y + Random.Range(13,15), 0), newBoom.transform.rotation);
        }
        transform.position += Vector3.up * 10;
    }
}
