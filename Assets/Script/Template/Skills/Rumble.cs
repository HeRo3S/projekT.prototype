using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Rumble", menuName = "Resources/Ability/Sorcery/Rumble", order = 0)]
public class Rumble : AbilityBase
{
    public override void Active()
    {
        if (CanActive())
        {
            base.Active();
            InstanceManager.Instance.player.Heal(curePotency);
        }
    }
}
