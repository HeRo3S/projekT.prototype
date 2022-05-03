using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Square : BroadswordBase
{
    public override void Start()
    {
        baseAttackPwr = 420;
        baseStaminaCost = 60;
        base.Start();
    }
}
