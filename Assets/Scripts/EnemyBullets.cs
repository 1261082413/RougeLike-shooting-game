using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullets : MonoBehaviour
{
    public float speed;
    private Vector3 direction;

    // Start is called before the first frame update
    void Start()
    {
        direction = PlayerController.instance.transform.position - transform.position;
        direction.Normalize();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += direction * speed * Time.deltaTime;
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            PlayerHealthController.instance.DamagePlayer();
            // Add your code here that should run when the player is hit
        }
        Destroy(gameObject);
    } // This closing bracket was missing to end the OnTriggerEnter2D method

    // This method shouldn't have the 'private' keyword as it is not valid in this context
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}

