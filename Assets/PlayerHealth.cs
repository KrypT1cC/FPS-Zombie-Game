
using UnityEngine;
using System.Collections;

public class PlayerHealth : MonoBehaviour
{

    public int currentHealth;
    public int maximumHealth = 100;
    public int time = 0;

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
        OnGUI();
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

}

