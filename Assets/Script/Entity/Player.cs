using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : EntityBase
{
    //Stat related value
    [SerializeField]
    protected float maxStamina;
    [SerializeField]
    protected float stamina;
    [SerializeField]
    protected float staminaRegen;

    public void FixedUpdate()
    {
        stamina = Mathf.Min(maxStamina, stamina + staminaRegen*Time.deltaTime);
    }
    public float GetStamina()
    {
        return stamina;
    }
    public void ConsumeStamina(int value)
    {
        stamina = Mathf.Max(0, stamina - value);
    }
}
