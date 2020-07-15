using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeleteMove : MonoBehaviour
{
    public float speed = 10f;

    void Start()
    {
        
    }

    void Update()
    {
        transform.Translate(Input.GetAxis("Horizontal") * speed * Time.deltaTime, 0, Input.GetAxis("Vertical") * speed * Time.deltaTime);
    }
}
