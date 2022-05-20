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
    protected Sprite icon;
    public virtual void Awake()
    {
        currentCD = 0;
    }
    public virtual bool IsValid()
    {
        return true;
    }
    public virtual bool CanActive()
    {
        if (InstanceManager.Instance.player == null) return false;
        return (
                manaCost <= InstanceManager.Instance.player.GetMana() &&
                staminaCost <= InstanceManager.Instance.player.GetStamina() &&
                healthCost < InstanceManager.Instance.player.GetHealth() &&
                currentCD <= 0
                ) ;
    }
    public Sprite GetIcon()
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
        InstanceManager.Instance.player.ConsumeStamina(staminaCost);
        InstanceManager.Instance.player.AdjustHealth(-healthCost);
        InstanceManager.Instance.player.ConsumeMana(manaCost);
        currentCD = cooldown;
    }
    public virtual void DoUpdate()
    {
        if(currentCD > 0)
        {
            currentCD -= Time.fixedDeltaTime;
        }
    }
    public virtual void SetCurrentCD(float value)
    {
        currentCD = value;
    }
}
