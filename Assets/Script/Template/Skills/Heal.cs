using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Heal : AbilityBase
{
    public override void Awake()
    {
        base.Awake();
        curePotency = 30;
        manaCost = 100;
        staminaCost = 200;
    }
    public override void Active()
    {
        if (CanActive())
        {
            base.Active();
            player.Heal(curePotency);
        }
    }
}
