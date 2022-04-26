using System.Collections.Generic;
using UnityEngine;

public abstract class BroadswordBase : WeaponBase
{
    protected HashSet<EnemyBase> hitList = new HashSet<EnemyBase>();

    public override void Start()
    {
        base.Start();
        weaponType = Enumeration.Weapon.BROADSWORD;
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBase hitEntity = collision.gameObject.GetComponent<EnemyBase>();
        if (hitEntity != null)
        {
            if (!hitList.Contains(hitEntity))
            {
                hitList.Add(hitEntity);
                hitEntity.TakeDamage(100);
            }
        }
    }
    public override void DoAttack()
    {
        if (canAttack)
        {
            canAttack = false;
            anim.SetFloat("Angle", player.GetRotation());
            anim.SetTrigger("LightAttack");
            player.ConsumeStamina(100);
        }
    }

    public override void EndAttack()
    {
        hitList.Clear();
        canAttack = true;
    }
    public void AfterAnimation()
    {
        EndAttack();
    }
}
