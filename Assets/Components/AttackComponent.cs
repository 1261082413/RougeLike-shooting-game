namespace Attack
{
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    public GameObject bullet;
    public Transform firePoint;
    public float fireRate;

    private float fireCounter;

    public void HandleAttack(bool shouldShoot)
    {
        if (shouldShoot)
        {
            RangedAttack();
            
        }
        else
        {
            MeleeAttack();
        }
    }

    private void RangedAttack()
    {
        if (fireCounter <= 0)
        {
            fireCounter = fireRate;
            Instantiate(bullet, firePoint.position, firePoint.rotation);
        }
    }

    private void MeleeAttack()
    {
        // Placeholder for melee attack logic
        // Implement melee attack logic here when ready
    }

    private void Update()
    {
        if (fireCounter > 0)
        {
            fireCounter -= Time.deltaTime;
        }
    }
}
}

