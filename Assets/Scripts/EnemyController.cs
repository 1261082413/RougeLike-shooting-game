using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public Rigidbody2D theRB;
    public float speed;

    public float rangeToPlayer;

    public Animator anim;

    public Vector3 move;

    public int health = 150;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Vector3.Distance(transform.position,PlayerController.instance.transform.position) < rangeToPlayer)
        {
            move = PlayerController.instance.transform.position - transform.position;
        }else{
            move = Vector3.zero;
        }
        move.Normalize();
        move.z = 0;
        transform.position += move *speed;
        //theRB.velocity = move * speed;

        if(move != Vector3.zero)
        {
            anim.SetBool("isMoving", true);
        }else
        {
            anim.SetBool("isMoving", false);

        }

    }
    public void DamageEnemy(int damage)
    {
        health -= damage;

        if(health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
