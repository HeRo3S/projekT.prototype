using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="RefillPotion", menuName ="Resources/Item/RecoveryItem/RefillPotion", order =0)]
public class RefillPotion : ItemBase 
{
    //refill health, mana, stamina stats
    [SerializeField]
    protected float healthRefillPotency;
    [SerializeField]
    protected float manaRefillPotency;
    [SerializeField]
    protected float staminaRefillPotency;

    public override void OnActive()
    {
        if (CanUse())
        {
            Player player = InstanceManager.Instance.player;
            base.OnActive();
            player.Heal(healthRefillPotency);
            player.RefillMana(manaRefillPotency);
            player.RefillStamina(staminaRefillPotency);
        }
    }
}
