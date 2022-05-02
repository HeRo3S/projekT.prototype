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
        GolemAttack golemAttack = Instantiate(AssetManager.Instance.pfGolemAttack, target.transform.position, Quaternion.identity).GetComponent<GolemAttack>();
    }

    public override void FixedUpdate()
    {
        if (!inAttackAnimation)
        {
            Vector2 moveDirection = target.transform.position - transform.position;
            if (moveDirection.magnitude > attackRange)
            {
                moveDirection /= moveDirection.magnitude;
                Move(moveDirection);
                anim.SetBool("isMoving", true);
                anim.SetFloat("LatestAngle", SplitRotationAngleInto(2));
            }
            else
            {
                rBody.velocity = Vector2.zero;
                anim.SetBool("isMoving", false);
                DoAttack();
            }
        }
    }
    
    public void AfterAttackAnimation()
    {
        inAttackAnimation = false;
    }
}
