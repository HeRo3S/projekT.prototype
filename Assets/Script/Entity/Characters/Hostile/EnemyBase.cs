using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : EntityBase, ITargetable
{
    protected float attackRange = 1.2f;
    protected GameObject target;
    protected float detectionRange = 8f;
    [SerializeField]
    protected int creditDrop;
    public GameObject GetTarget()
    {
        return target;
    }
    public override void Awake()
    {
        base.Awake();
    }

    public void Start()
    {
        target = InstanceManager.Instance.player.gameObject;

    }
    public virtual void Update()
    {
        if (target == null) return;
        Vector2 moveDirection = target.transform.position - transform.position;
        if (moveDirection.magnitude > attackRange && inAttackAnimation != false)
        {
            moveDirection /= moveDirection.magnitude;
            Move(moveDirection);
        }
        else
        {
            rBody.velocity = Vector2.zero;
        }
    }
    public override void SelfDestruct()
    {
        base.SelfDestruct();
        InstanceManager.Instance.player.SpendBudget(-creditDrop); 
    }
}
