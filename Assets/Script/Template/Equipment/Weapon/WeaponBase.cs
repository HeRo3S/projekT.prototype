using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    //GameObject Component
    protected Animator anim;
    protected Player player;
    protected bool canAttack;

    //Stat related value

    protected int attackPwr;
    protected Enumeration.Weapon weaponType;

    //Put extra start call handler in ExtraStart instead of overwrite

    public virtual void Start()
    {
        //setup animation controller
        anim = gameObject.GetComponent<Animator>();
        player = InstanceManager.Instance.player;
        canAttack = true;
    }

    public void FixedUpdate()
    {
        anim.SetFloat("LatestAngle", player.SplitRotationAngleInto4());
    }

    public abstract void DoAttack();

    public abstract void EndAttack();

}
