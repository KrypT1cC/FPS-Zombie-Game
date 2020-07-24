using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    //public CharacterController controller;

    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 3f;

    public float groundDistance = 0.4f;
 
    Vector3 velocity;
    public bool isGrounded;


    void Update()
    {


        /*
        if(isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }
        */
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        transform.Translate(x * speed * Time.deltaTime, 0, z * speed * Time.deltaTime);
        //Vector3 move = transform.right * x + transform.forward * z;

        //controller.Move(move * speed * Time.deltaTime);

        if(Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            //velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            GetComponent<Rigidbody>().AddForce(Vector3.up * jumpHeight, ForceMode.Impulse);
            print("jump");
        }

        //velocity.y += gravity * Time.deltaTime;

        //controller.Move(velocity * Time.deltaTime);


    }
    void OnCollisionStay(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = true;
           
        }
    }
    void OnCollisionExit(Collision col)
    {
        if (col.gameObject.tag == "Ground")
        {
            isGrounded = false;

        }
    }
}
