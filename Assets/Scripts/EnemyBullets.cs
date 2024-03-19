using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : MonoBehaviour
{
    public float speed;
    private Vector3 direction;

    
    void Start()
    {
        direction = PlayerController.instance.transform.position - transform.position;
        direction.Normalize();
    }

    
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    void OnTriggerEnter2D(Collider2D other)
{
    if (other.CompareTag("Player"))
    {
        PlayerHealthController.instance.DamagePlayer();
        Destroy(gameObject); 
    }
    else if (other.CompareTag("Breakable")) 
    {
        Destroy(gameObject); 
    }
}


}