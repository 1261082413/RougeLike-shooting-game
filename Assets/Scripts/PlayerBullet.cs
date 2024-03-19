using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Attack;
public class NewBehaviourScript : MonoBehaviour
{
    public float speed = 7.5f;
    public Rigidbody2D theRB;

    public GameObject impactEffect;

    public int damageToGive = 50;
    // Start is called before the first frame update

    void Start()
    {
        Collider2D myCollider = GetComponent<Collider2D>();
        foreach (var bullet in FindObjectsOfType<NewBehaviourScript>())
        {
            Collider2D theirCollider = bullet.GetComponent<Collider2D>();
            if (theirCollider != myCollider)
            {
                Physics2D.IgnoreCollision(myCollider, theirCollider);
            }
        }
    }
    void Update()
    {
        theRB.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        Instantiate(impactEffect, transform.position, transform.rotation);
        Destroy(gameObject);

        if(other.tag == "Enemy")
        {
            other.GetComponent<EnemyController>().DamageEnemy(damageToGive);
        }
        else if(other.tag == "EnenmyBullet") 
        {
            Destroy(other.gameObject); 
        }
        
       
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
