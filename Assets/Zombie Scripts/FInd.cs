using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class FInd : MonoBehaviour
{/*
    public Transform player;
    public int MoveSpeed = 4;
    public float MinDist = 0.1f;
    public bool zombieMove;


    void Start()
    {
     
    }

    void FixedUpdate()
    {
        transform.LookAt(player);

        if (Vector3.Distance(transform.position, player.position) >= MinDist)
        {
            //transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            Vector3 newVelocity = new Vector3(transform.forward.x, GetComponent<Rigidbody>().velocity.y, transform.forward.z) * MoveSpeed * Time.deltaTime;
            GetComponent<Rigidbody>().AddForce(newVelocity, ForceMode.Impulse);
        }

        if (Vector3.Distance(transform.position, player.position) <= MinDist)
        {

        }

    }
*/
    public Transform player;
    private GameObject wayPoint;
    private Vector3 wayPointPos;
    //This will be the zombie's speed. Adjust as necessary.
    private float speed = 5.0f;
    void Start()
    {
        //At the start of the game, the zombies will find the gameobject called wayPoint.
        wayPoint = GameObject.Find("Waypoint");
    }

    void Update()
    {
        GetComponent<Animator>().SetBool("isWalking", true);
        wayPointPos = new Vector3(wayPoint.transform.position.x, transform.position.y, wayPoint.transform.position.z);
        Vector3 look = new Vector3(player.position.x, transform.position.y, player.position.z);
        transform.LookAt(look);
        //Here, the zombie's will follow the waypoint.
        transform.position = Vector3.MoveTowards(transform.position, wayPointPos, speed * Time.deltaTime);
    }
}
