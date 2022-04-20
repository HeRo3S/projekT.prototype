using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbilityBase : ScriptableObject
{
    //Ability Information
    [SerializeField]
    protected string abilityName;
    [SerializeField]
    protected string abilityDescription;
    //Ability Stat
    [SerializeField]
    protected int resourceCost;
    [SerializeField]
    protected Enumeration.Ability abilityType;
    [SerializeField]
    protected Enumeration.Weapon weaponType;
    public void Active() { }
    

}
