using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Golem : EnemyBase 
{
    public override void Awake()
    {
        attackRange = 3f;
        anim = gameObject.GetComponent<Animator>();
        base.Awake();
        
    }
    public void DoAttack()
    {
        //set inAttackAnimation flag
        inAttackAnimation = true;
        //set AttackAngle value
        anim.SetFloat("AttackAngle", SplitRotationAngleInto(2));
        //set trigger isAttack
        anim.SetTrigger("isAttack");
        Instantiate(AssetManager.Instance.pfGolemAttack, target.transform.position, Quaternion.identity);
    }

    public override void Update()
    {
        if (!inAttackAnimation)
        {
            Vector2 moveDirection = target.transform.position - transform.position;
            if (moveDirection.magnitude <= detectionRange)
            {
                if (moveDirection.magnitude > attackRange)
                {
                    moveDirection /= moveDirection.magnitude;
                    Move(moveDirection);
                    anim.SetBool("isMoving", true);
                    anim.SetFloat("LatestAngle", SplitRotationAngleInto(2));
                }
                else
                {
                    Move(Vector2.zero);
                    DoAttack();
                }
            }
            else
            {
                Move(Vector2.zero);
            }
        }
    }

    public override bool Move(Vector2 moveDirection)
    {
        if(moveDirection == Vector2.zero)
        {
            anim.SetBool("isMoving", false);
        }
        return base.Move(moveDirection);
    }
    public void AfterAttackAnimation()
    {
        inAttackAnimation = false;
    }
}
