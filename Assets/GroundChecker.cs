using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public GameObject player;
    void OnTriggerStay(Collider col)
    {
        if(col.tag == "Ground")
        {
            player.GetComponent<PlayerMovement>().isGrounded = true;
            print("testing");  
        }
    }
    void OnTriggerExit(Collider col)
    {
        if (col.tag == "Ground")
        {
            player.GetComponent<PlayerMovement>().isGrounded = false;

        }
    }
}
