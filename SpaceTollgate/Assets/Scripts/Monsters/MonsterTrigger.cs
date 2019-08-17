using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]
[RequireComponent(typeof(Rigidbody2D))]
public class MonsterTrigger : MonoBehaviour
{
    public Monster owner;
    public int triggerIdx;
    private void Start()
    {
        owner = GetComponentInParent<Monster>();
        triggerIdx = owner.nextIdx++;
        owner.isTriggersEnter.Add(-1);
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Tollgate") && owner.isTriggersEnter[triggerIdx] <= 0)
        {
            owner.isTriggersEnter[triggerIdx] = 0;
        }
    }

    private void OnTriggerExit2D(Collider2D col)
    {
        if (col.CompareTag("Tollgate") && owner.isTriggersEnter[triggerIdx] == 0)
        {
            owner.isTriggersEnter[triggerIdx] = 1;
            owner.CheckToll();
        }
    }
}
