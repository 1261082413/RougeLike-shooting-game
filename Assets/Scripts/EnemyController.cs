using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float speed;

    public float rangeToChasePlayer;
    public float rangeToAttackPlayer;

    public Animator anim;

    public Vector3 moveDirection;

    public int health = 150;

    public GameObject[] deathSplatter;
    public GameObject hitEffect;

    public bool shouldShoot;
    public GameObject bullet;

    public Transform firePoint;
    public float fireRate;

    private float fireCounter;
    private float patrolCounter;
    private Vector3 patrolDestination;

    public SpriteRenderer theBody;

    private enum EnemyState { Idle, Patrolling, Chasing, Attacking }
    private EnemyState currentState = EnemyState.Idle;

    // Start is called before the first frame update
    void Start()
    {
        // Initialize patrol destination or other variables if needed
    }

    // Update is called once per frame
    void Update()
    {
        switch (currentState)
        {
            case EnemyState.Idle:
                // Wait or perform simple behavior
                break;
            case EnemyState.Patrolling:
                Patrol();
                break;
            case EnemyState.Chasing:
                ChasePlayer();
                break;
            case EnemyState.Attacking:
                AttackPlayer();
                break;
        }

        UpdateState();
        UpdateAnimation();
    }

    void Patrol()
    {
        // Implement patrol logic here
        // Example: Move to a new random position after certain time
    }

    void ChasePlayer()
    {
        moveDirection = PlayerController.instance.transform.position - transform.position;
        moveDirection.Normalize();
        transform.position += moveDirection * speed * Time.deltaTime;
    }

    void AttackPlayer()
    {
        // Implement different types of attacks here
        // Example: Melee, Ranged, etc.
    }

    void UpdateState()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, PlayerController.instance.transform.position);
        if (distanceToPlayer < rangeToAttackPlayer)
        {
            currentState = EnemyState.Attacking;
        }
        else if (distanceToPlayer < rangeToChasePlayer)
        {
            currentState = EnemyState.Chasing;
        }
        else
        {
            currentState = EnemyState.Patrolling;
        }
    }

    void UpdateAnimation()
    {
        if (moveDirection != Vector3.zero)
        {
            anim.SetBool("isMoving", true);
        }
        else
        {
            anim.SetBool("isMoving", false);
        }
    }

    public void DamageEnemy(int damage)
    {
        health -= damage;
        Instantiate(hitEffect, transform.position, transform.rotation);

        if (health <= 0)
        {
            int selectedSplatter = Random.Range(0, deathSplatter.Length);
            int rotation = Random.Range(0, 4);
            Instantiate(deathSplatter[selectedSplatter], transform.position, Quaternion.Euler(0f, 0f, rotation * 90f));
            Destroy(gameObject);
        }
    }
}
