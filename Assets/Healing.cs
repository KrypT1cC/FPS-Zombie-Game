using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healing : MonoBehaviour
{
    int timeHeal = 0;

    void Start()
    {
        
    }

    void Update()
    {
        FindObjectOfType<PlayerHealth>().currentHealth++;
    }
}
