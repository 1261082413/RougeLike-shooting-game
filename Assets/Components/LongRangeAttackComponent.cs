using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LongRangeAttackComponent : AttackComponent
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    // override attack
    public override void StartAttack()
    {
        Debug.Log("LongRangeAttackComponent StartAttack");
    }
}
