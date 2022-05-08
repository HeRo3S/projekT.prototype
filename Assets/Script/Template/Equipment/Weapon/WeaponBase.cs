using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class WeaponBase : MonoBehaviour
{
    //GameObject Component
    protected Animator anim;
    protected Player player;

    //Stat related value
    [SerializeField]
    protected int baseAttackPwr;
    [SerializeField]
    protected int baseStaminaCost;
    protected float staminaCost;
    protected float attackPwr;
    protected Enumeration.Weapon weaponType;

    //Put extra start call handler in ExtraStart instead of overwrite

    public virtual void Start()
    {
        //setup animation controller
        anim = gameObject.GetComponent<Animator>();
        player = InstanceManager.Instance.player;
        staminaCost = baseStaminaCost;
        attackPwr = baseAttackPwr;
    }

    public void Update()
    {
        anim.SetFloat("LatestAngle", player.SplitRotationAngleInto(4));
    }

    public virtual void DoAttack()
    {
        player.Move(Vector2.zero);
        player.inAttackAnimation = true;
        player.UpdateRotation();
        player.ConsumeStamina(staminaCost);
    }
    public virtual bool CanAttack()
    {
        return (!player.inAttackAnimation && staminaCost <= player.GetStamina());
    }
    public virtual void EndAttack()
    {
        player.inAttackAnimation = false;
    }

}
