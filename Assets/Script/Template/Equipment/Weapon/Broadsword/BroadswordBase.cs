using System.Collections.Generic;
using UnityEngine;

public abstract class BroadswordBase : WeaponBase
{
    protected HashSet<EnemyBase> hitList = new HashSet<EnemyBase>();
    protected Collider2D hitBox;
    public override void Start()
    {
        base.Start();
        weaponType = Enumeration.Weapon.BROADSWORD;
        hitBox = gameObject.GetComponent<Collider2D>();
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBase hitEntity = collision.gameObject.GetComponent<EnemyBase>();
        if (hitEntity != null)
        {
            if (!hitList.Contains(hitEntity))
            {
                hitList.Add(hitEntity);
                hitEntity.TakeDamage(attackPwr);
            }
        }
    }
    public override void DoAttack()
    {
        if (CanAttack())
        {
            base.DoAttack();
            hitBox.enabled = true;
            anim.SetFloat("AttackAngle", player.SplitRotationAngleInto(8));
            anim.SetTrigger("LightAttack");
            FindObjectOfType<AudioManager>().Play("broadsword_attack");
        }
    }
    public override void EndAttack()
    {
        base.EndAttack();
        hitList.Clear();
    }
    public void AfterAnimation()
    {
        EndAttack();
    }
}
