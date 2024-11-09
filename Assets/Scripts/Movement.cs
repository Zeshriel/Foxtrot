using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float runSpeed;
    public float jumpSpeed;
    Rigidbody2D myBod;
    bool isLeft;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        myBod = GetComponent<Rigidbody2D>();
        isLeft = false;
        isGrounded = false;
    }

    // Update is called once per frame
    void Update()
    {

        if(Input.GetButtonDown("Jump") && isGrounded && !isLeft){
            isGrounded = false;
            isLeft = true;
            myBod.rotation *= -1;
        }
        if(Input.GetButtonDown("Jump") && isGrounded && isLeft){
            isGrounded = false;
            isLeft = false;
            myBod.rotation *= -1;
        }

        if(!isLeft && !isGrounded){
            transform.position += (Vector3.right * jumpSpeed * Time.deltaTime + Vector3.up * runSpeed * Time.deltaTime);
        }
        if(isLeft && !isGrounded){
            transform.position += (Vector3.left * jumpSpeed * Time.deltaTime + Vector3.up * runSpeed * Time.deltaTime);
        }
        if(!isLeft && isGrounded){
            transform.position += Vector3.up * runSpeed * Time.deltaTime;
        }
        if(isLeft && isGrounded){
            transform.position += Vector3.up * runSpeed * Time.deltaTime;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject otherGO = collision.gameObject;
        //Do Stuff
        if(otherGO.name.Contains("Wall")){
            isGrounded = true;
        }
    }

}
