using System.Collections;
using System.Collections.Generic;
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

    void Update()
    {
        transform.LookAt(player);

        if (Vector3.Distance(transform.position, player.position) >= MinDist)
        {
            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
        }

        if (Vector3.Distance(transform.position, player.position) <= MinDist)
        {

        }

    }




}
