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
        speed = 3.5f;
    }

    public void Start()
    {
        target = InstanceManager.Instance.player.gameObject;
    }
    public void FixedUpdate()
    {
        Vector2 moveVector = target.GetComponent<Rigidbody2D>().position - rBody.position;
        if (moveVector.magnitude > attackRange)
        {
            float moveVectorAbs = moveVector.magnitude * moveVector.magnitude;
            moveVector.Set(Mathf.Sqrt(moveVector.x * moveVector.x / moveVectorAbs) * (moveVector.x / Mathf.Abs(moveVector.x)),
                           Mathf.Sqrt(moveVector.y * moveVector.y / moveVectorAbs) * (moveVector.y / Mathf.Abs(moveVector.y)));
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
