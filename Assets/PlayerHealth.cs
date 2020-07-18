
using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

    public int currentHealth;
    public int maximumHealth = 100;
    public int healingTimeCounter = 0;
    public int time = 0;

    public float hbLength;

    public bool zombieTouching = false;

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

    void TakeDamage()
    {
        currentHealth -= 5;
    }

    void Healing ()
    {  
        if (zombieTouching == false && currentHealth < maximumHealth)
        {
            healingTimeCounter++;
            if (healingTimeCounter == 50)
            {
                ChangeHealth(1);
                healingTimeCounter = 0;
            }
        }
    }
       

    private void OnTriggerEnter(Collider other)
    {
        zombieTouching = true;
    }

    private void OnTriggerStay(Collider col)
    { 
        if (col.gameObject.tag == "Zombie")
        {
            time++;
            if (time == 50)
            {
                TakeDamage();
                time = 0;
            }

        }
    }

    IEnumerator WaitTime()
    {
        yield return new WaitForSeconds(5f);
        zombieTouching = false;
        time = 0;
    }

    private void OnTriggerExit(Collider other)
    {
        StartCoroutine(WaitTime());
    }

}

