
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
        
        //Todo: Add damage animation

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //Todo: Add death animation
        
        Debug.Log("I am dead");

        Destroy(gameObject);
    }
}
