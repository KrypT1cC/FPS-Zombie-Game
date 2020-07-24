
using System.Runtime.ExceptionServices;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamege (float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            FindObjectOfType<Score>().AddPoints(10);
            Die();
        }
    }

    void Die ()
    {
        Destroy(gameObject);
    }
}
