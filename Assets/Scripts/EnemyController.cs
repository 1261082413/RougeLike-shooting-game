using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Attack
{
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

        // AttackComponent reference
        public AttackComponent attackComponent;

        public SpriteRenderer theBody;

        private enum EnemyState { Idle, Patrolling, Chasing, Attacking }
        private EnemyState currentState = EnemyState.Idle;

        void Start()
        {
            // Initialize patrol destination or other variables if needed
        }

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
                case EnemyState.Attacking: // 同样的处理逻辑适用于追踪和攻击状态
                    ChasePlayer();
                    break;
            }

            if (currentState == EnemyState.Attacking)
            {
                AttackPlayer();
            }

            UpdateState();
            UpdateAnimation();
        }

        void Patrol()
        {
            // Patrol logic here
        }

        void ChasePlayer()
        {
            moveDirection = PlayerController.instance.transform.position - transform.position;
            moveDirection.Normalize();
            theRB.MovePosition(transform.position + moveDirection * speed * Time.deltaTime);
        }

        void AttackPlayer()
        {
            if (attackComponent != null)
            {
                attackComponent.HandleAttack(shouldShoot);
            }
            else
            {
                Debug.LogWarning("AttackComponent is not assigned on " + gameObject.name);
            }
        }

        void OnDrawGizmosSelected()
        {
            // Draw a yellow sphere at the transform's position
            Gizmos.color = Color.yellow;
            Gizmos.DrawSphere(transform.position, rangeToChasePlayer);
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
            anim.SetBool("isMoving", moveDirection != Vector3.zero);
        }

        public void DamageEnemy(int damage)
        {
            health -= damage;
            Instantiate(hitEffect, transform.position, transform.rotation);

            if (health <= 0)
            {
                int LayerEnemy = LayerMask.NameToLayer("Ground");
                int selectedSplatter = Random.Range(0, deathSplatter.Length);
                var bloodSprite = Instantiate(deathSplatter[selectedSplatter], transform.position, Quaternion.Euler(0f, 0f, Random.Range(0, 360f)));
                bloodSprite.gameObject.layer = LayerEnemy;
                Destroy(gameObject);
            }
        }
    }
}
