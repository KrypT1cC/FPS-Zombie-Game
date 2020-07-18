
using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

    public int currentHealth;
    public int maximumHealth = 100;
    public int healTimeCounter = 0;
    public int time = 0;
    

    public bool zombieTouch = false;

    public float hbLength;

    // Use this for initialization
    void Start()
    {
        currentHealth = maximumHealth;

        hbLength = Screen.width / 2;


    }
    // Update is called once per frame
    void Update()
    {
        ChangeHealth(0);
        Healing();
    }

    void OnGUI()
    {
        GUI.Box(new Rect(10, 10, hbLength, 30), currentHealth + " / " + maximumHealth);
    }

    public void ChangeHealth(int health)
    {
        currentHealth += health;

        hbLength = (Screen.width / 2) * (currentHealth / (float)maximumHealth);
    }

    public void Healing()
    {   
        if (zombieTouch == false)
        {
            healTimeCounter++;
            if (healTimeCounter == 50)
            {
                if (currentHealth < 100)
                {
                    ChangeHealth(1);
                }

                healTimeCounter = 0;
            }

        } 

    }

    private void OnTriggerStay(Collider col)
    {
        zombieTouch = true;
     
        if (col.gameObject.tag == "Zombie")
        {
            time++;
            if (time == 50)
            {
                ChangeHealth(-5);
                time = 0;
            }

        }
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(5f); 
        zombieTouch = false; 
        time = 0;
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(WaitTime());

    }

}

