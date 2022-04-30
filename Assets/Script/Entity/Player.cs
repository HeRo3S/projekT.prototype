using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : EntityBase
{
    //Stat related value
    [SerializeField]
    protected float maxMana;
    [SerializeField]
    protected float mana;
    [SerializeField]
    protected float maxStamina;
    [SerializeField]
    protected float stamina;
    [SerializeField]
    protected float staminaRegen;
    //Weapon Object
    [SerializeField]
    protected GameObject currentWeaponObject;
    protected WeaponBase currentWeapon;
    protected List<GameObject> weaponList;
    protected int currentWeaponIndex;
    public override void Awake()
    {
        base.Awake();
        //Register to manager
        InstanceManager.Instance.player = this;
        anim = gameObject.GetComponent<Animator>();
        //Weapon Initilization
        weaponList = new List<GameObject>
        {
            AssetManager.Instance.pfBroadSword,
            AssetManager.Instance.pfBow
        };
        currentWeaponIndex = 1;
        SwitchNextWeapon();
    }

    public void FixedUpdate()
    {
        stamina = Mathf.Min(maxStamina, stamina + staminaRegen*Time.deltaTime);
    }

    public override bool Move(Vector2 moveVector)
    {
        anim.SetFloat("SpeedX", moveVector.x);
        anim.SetFloat("SpeedY", moveVector.y);
        return base.Move(moveVector);
    }
    public void ConsumeStamina(int value)
    {
        stamina = Mathf.Max(0, stamina - value);
    }
    public WeaponBase GetCurrentWeapon()
    {
        return currentWeapon;
    }
    public float GetStamina()
    {
        return stamina;
    }
    public float GetMaxStamina()
    {
        return maxStamina;
    }
    public float GetMana()
    {
        return mana;
    }
    public float GetMaxMana()
    {
        return maxMana;
    }
    public void SwitchNextWeapon()
    {
        if(currentWeapon != null)
        {
            Destroy(currentWeapon.gameObject);
        }
        currentWeaponIndex = (currentWeaponIndex + 1) % weaponList.Count;
        GameObject weapon = Instantiate(weaponList[currentWeaponIndex]);
        weapon.transform.SetParent(currentWeaponObject.transform, false);
        currentWeapon = weapon.GetComponent<WeaponBase>();
    }
}
