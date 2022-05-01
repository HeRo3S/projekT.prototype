using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : EntityBase, ITargetable
{
    protected float attackRange = 1.2f;
    protected GameObject target;
    public GameObject GetTarget()
    {
        return target;
    }
    public new void Awake()
    {
        base.Awake();
    }

    public void Start()
    {
        target = InstanceManager.Instance.player.gameObject;

    }
    public void FixedUpdate()
    {
        Vector2 moveDirection = target.transform.position - transform.position;
        if (moveDirection.magnitude > attackRange)
        {
            moveDirection /= moveDirection.magnitude;
            Move(moveDirection);
        }
        else
        {
            rBody.velocity = Vector2.zero;
        }
    }
}
