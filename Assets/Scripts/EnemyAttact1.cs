using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public float attackRange = 1f;  
    public int attackDamage = 20;   
    public float attackRate = 2f;   

    private float lastAttackTime;   
    private Transform player;       

    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform; 
        lastAttackTime = Time.time;  
    }

    
    void Update()
    {
        if (player != null && IsPlayerInRange() && IsAttackCooldownComplete())
        {
            Attack();
        }
    }

    private bool IsPlayerInRange()
    {
        
        return Vector3.Distance(transform.position, player.position) <= attackRange;
    }

    private bool IsAttackCooldownComplete()
    {
        
        return Time.time >= lastAttackTime + (1f / attackRate);
    }

    private void Attack()
    {
        
        Debug.Log("Attacking the player!");

        
       

        lastAttackTime = Time.time; 
    }
}
