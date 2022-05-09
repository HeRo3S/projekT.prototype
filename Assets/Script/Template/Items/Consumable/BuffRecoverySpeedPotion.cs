using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="BuffRecoverSpeedPotions", menuName ="Resources/Item/RecoveryItem/BuffRecoverSpeedPotions", order = 1)]
public class BuffRecoverySpeedPotion : ItemBase 
{
    //buff stats
    [SerializeField]
    protected float healthRecoverSpeedBoostRate;
    [SerializeField]
    protected float manaRecoverSpeedBoostRate;
    [SerializeField]
    protected float staminaRecoverSpeedBoostRate;

}
