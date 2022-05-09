using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="BuffStatsPotion", menuName ="Resources/Item/RecoveryItem/BuffStatsPotion", order = 2)]
public class BuffStatsPotion : ItemBase 
{
    [SerializeField]
    protected float strengthBoostRate;
    [SerializeField]
    protected float defenseBoostRate;
    [SerializeField]
    protected float magicBoostRate;

}
