using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BowBase : WeaponBase
{
    public override void DoAttack()
    {
        base.DoAttack();
        Arrow arrow = Instantiate(AssetManager.Instance.pfArrow, player.transform.position, Quaternion.identity).GetComponent<Arrow>();
        arrow.InitValue(player.GetDirection(), 5, player.GetRotation(), 120);
        base.EndAttack();
    }

}
