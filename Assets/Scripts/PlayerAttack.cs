using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] private float attackCooldown = 1;
    [SerializeField] private float attackRange = 0.5f;
    [SerializeField] private float damage = 20;
    [SerializeField] private Transform AttackPoint;
    [SerializeField] private LayerMask enemyLayer;
    [SerializeField] private bool drawSphere = false;
    private float cooldownTimer = Mathf.Infinity;


    private void Update()
    {
        if (Input.GetKey(KeyCode.Space) &&  cooldownTimer > attackCooldown)
        {
            Attack();
        }
        cooldownTimer += Time.deltaTime;
    }

    private void Attack()
    {
        //TODO: Add attack animation
        
        Debug.Log("Attacked");

        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(AttackPoint.position,attackRange, enemyLayer);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy>().takeDamage(damage);
        }
        cooldownTimer = 0;
    }

    
    //Draws attack sphere for debug purposes
    private void OnDrawGizmosSelected()
    {
        if (drawSphere)
        {
            Gizmos.DrawWireSphere(AttackPoint.position, attackRange);
        }
    }
}