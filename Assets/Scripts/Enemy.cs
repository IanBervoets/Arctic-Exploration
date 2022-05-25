
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private float maxHealth = 100;
    private float currentHealth;

    private void Start()
    {
        currentHealth = maxHealth;
    }

    public void takeDamage(float damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
              Die();
        }
    }

    private void Die()
    {
        Debug.Log("I am dead");

        Destroy(gameObject);
    }
}
