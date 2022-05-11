using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="RecoveryPotion", menuName ="Resources/Item/RecoveryItem/RecoveryPotion", order =0)]
public class RecoveryPotion : ItemBase 
{
    //refill health, mana, stamina stats
    [SerializeField]
    protected float healRecoveryPotency;
    [SerializeField]
    protected float manaRecoveryPotency;
    [SerializeField]
    protected float staminaRecoveryPotency;

    public override void OnActive()
    {
        if (CanUse())
        {
            Player player = InstanceManager.Instance.player;
            base.OnActive();
            player.Heal(healRecoveryPotency);
            player.RefillMana(manaRecoveryPotency);
            player.RefillStamina(staminaRecoveryPotency);
        }
    }
}
