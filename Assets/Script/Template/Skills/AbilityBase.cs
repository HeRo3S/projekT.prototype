using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public abstract class AbilityBase : ScriptableObject
{
    //Ability Information
    [SerializeField]
    protected string abilityName;
    [SerializeField]
    protected string abilityDescription;
    //Ability Stat
    [SerializeField]
    protected float curePotency;
    [SerializeField]
    protected float strikePotency;
    [SerializeField]
    protected float manaCost;
    [SerializeField]
    protected float healthCost;
    [SerializeField]
    protected float staminaCost;
    [SerializeField]
    protected float cooldown;
    protected float currentCD;
    [SerializeField]
    protected Enumeration.Ability abilityType;
    [SerializeField]
    protected Enumeration.Weapon weaponType;
    //Skill display
    [SerializeField]
    protected Image icon;
    //Needed references
    protected Player player;
    public virtual void Awake()
    {
        player = InstanceManager.Instance.player;
    }
    public virtual bool IsValid()
    {
        return true;
    }
    public virtual bool CanActive()
    {
        return (
                manaCost <= player.GetMana() &&
                staminaCost <= player.GetStamina() &&
                healthCost < player.GetHealth()
                );
    }
    public Image GetIcon()
    {
        return icon;
    }
    public float GetCooldown()
    {
        return cooldown;
    }
    public float GetCurrentCD()
    {
        return currentCD;
    }
    public virtual void Active()
    {
        player.ConsumeStamina(staminaCost);
        player.TakeDamage(healthCost);
        player.ConsumeMana(manaCost);
    }
}
