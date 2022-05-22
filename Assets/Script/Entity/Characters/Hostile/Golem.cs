using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Golem : EnemyBase 
{
    protected Vector2 homePos;
    public override void Awake()
    {
        attackRange = 3f;
        anim = gameObject.GetComponent<Animator>();
        hpBar = transform.Find("Canvas").GetChild(0).GetChild(0).GetComponent<Image>();
        base.Awake();
        homePos = rBody.position;
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
        if (target == null) return;
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
                moveDirection = homePos - (Vector2)transform.position;
                if (moveDirection.magnitude > 0.25f)
                {
                    Move(moveDirection / moveDirection.magnitude);
                    anim.SetBool("isMoving", true);
                    anim.SetFloat("LatestAngle", SplitRotationAngleInto(2));
                }
                else
                {
                    Move(Vector2.zero);
                }
            }
        }
        UpdateHealthbar();
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

    protected void UpdateHealthbar()
    {

        hpBar.fillAmount = (healthPts / maxHealth);
    }
}
