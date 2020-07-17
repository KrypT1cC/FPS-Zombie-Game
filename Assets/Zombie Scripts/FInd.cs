using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using System.Threading;
using UnityEngine;

public class FInd : MonoBehaviour
{
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




}
