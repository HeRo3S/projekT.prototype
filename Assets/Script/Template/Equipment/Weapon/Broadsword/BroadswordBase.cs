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
            //rotation value is in the range [-180;180]
            //discreet transform all the rotation value into 8 values below:
            // [-135    -90    -45  0   45   90   135   180]
            // [   -3    -2     -1  0    1    2     3     4]: divided by 45 to get the int number
            // [-0.75  -0.5  -0.25  0 0.25  0.5  0.75     1]: divided by 4 to get the float number in the range [-1;1]
            float roundedAngle = ((int)player.GetRotation() / 45) / 4.0f;
            anim.SetFloat("Angle", roundedAngle);
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
