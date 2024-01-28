using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackComponent : MonoBehaviour
{
    [SerializeField] private bool isAutoEnabled = true;
    private bool isEnabled = true;

    // Start is called before the first frame update
    void Start()
    {
        isEnabled = isActiveAndEnabled;
    }

    // Update is called once per frame
    void Update()
    {
        if(isEnabled)
        {
            StartAttack();
        }
    }

    public virtual void StartAttack()
    {
        Debug.Log("AttackComponent StartAttack");
    }

    public void EnableAttack(bool Value)
    {
        isEnabled = Value;
    }
}
