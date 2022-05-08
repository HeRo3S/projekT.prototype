using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AddressableAssets;
using UnityEngine.UI;
[CreateAssetMenu(fileName = "Heal",menuName = "Resources/Ability/Sorcery/Heal",order = 0)]
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
            InstanceManager.Instance.player.Heal(curePotency);
        }
    }
}
