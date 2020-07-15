
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public float health = 100f;

    public void TakeDamege (float amount)
    {
        health -= amount;
        if (health <= 0f)
        {
            Die();
        }
    }

    void Die ()
    {
        Destroy(gameObject);
    }
}
