using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float initialSpeed = 2f;
    public float acceleration = 0.01f; // Slow acceleration over time
    private float currentSpeed;
    private Rigidbody2D myBod;

    // Start is called before the first frame update
    void Start()
    {
        myBod = GetComponent<Rigidbody2D>();
        currentSpeed = initialSpeed; // Set the initial speed
    }

    // Update is called once per frame
    void Update()
    {
        currentSpeed += acceleration * Time.deltaTime; // Gradually increase speed
        myBod.velocity = new Vector2(0, currentSpeed); // Apply the current speed as the y-velocity
    }
}
