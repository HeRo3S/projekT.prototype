using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    //GameObject Component
    protected Animator anim;
    protected Player player;

    //Stat related value

    protected int attackPwr;
    protected Enumeration.Weapon weaponType;

    //Put extra start call handler in ExtraStart instead of overwrite

    public virtual void Start()
    {
        //setup animation controller
        anim = gameObject.GetComponent<Animator>();
        player = InstanceManager.Instance.player;
    }

    public void FixedUpdate()
    {
        anim.SetFloat("LatestAngle", player.SplitRotationAngleInto4());
    }

    public virtual void DoAttack()
    {
        if (!player.inAttackAnimation)
        {
            player.Move(Vector2.zero);
            player.inAttackAnimation = true;
            player.UpdateRotation();
        }
    }

    public virtual void EndAttack()
    {
        player.inAttackAnimation = false;
    }

}
