using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBase : EntityBase
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
        speed = 3.5f;
    }

    public void Start()
    {
        target = InstanceManager.Instance.player;
    }
    public void FixedUpdate()
    {
        Vector2 moveVector = target.GetComponent<Rigidbody2D>().position - rBody.position;
        if (moveVector.magnitude > attackRange)
        {
            float moveVectorAbs = Mathf.Abs(moveVector.x) + Mathf.Abs(moveVector.y);
            moveVector.Set(moveVector.x / moveVectorAbs, moveVector.y / moveVectorAbs);
            if (!Move(moveVector))
            {
                if (!Move(new Vector2(moveVector.x < 0 ? -1 : 1, 0)))
                {
                    Move(new Vector2(0, moveVector.y < 0 ? -1 : 1));
                }
            }
        }
        else
        {
            rBody.velocity = Vector2.zero;
        }
    }
}
