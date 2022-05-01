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
    //Targeting
    public GameObject target;

    //Status (sorta)
    public bool inAttackAnimation;

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
        inAttackAnimation = false;
    }

    public void FixedUpdate()
    {
        stamina = Mathf.Min(maxStamina, stamina + staminaRegen*Time.deltaTime);
        anim.SetFloat("LatestAngle", SplitRotationAngleInto4());
    }

    public override bool Move(Vector2 moveDirection)
    {
        if (!inAttackAnimation)
        {
            base.Move(moveDirection);
        }
        anim.SetBool("IsRunning", moveVector != Vector2.zero);
        return true;
    }
    public override void UpdateRotation()
    {
            if (moveVector != Vector2.zero)
            {
                direction = moveVector / moveVector.magnitude;
            }
            else
            {
                //Rotate to target if available
                if (target != null)
                {
                    direction = target.transform.position - transform.position;
                    direction /= direction.magnitude;
                }
            }
            rotation = (float)(System.Math.Atan2(direction.y, direction.x) / System.Math.PI * 180f);

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
        if (!inAttackAnimation)
        {
            if (currentWeapon != null)
            {
                Destroy(currentWeapon.gameObject);
            }
            currentWeaponIndex = (currentWeaponIndex + 1) % weaponList.Count;
            GameObject weapon = Instantiate(weaponList[currentWeaponIndex]);
            weapon.transform.SetParent(currentWeaponObject.transform, false);
            currentWeapon = weapon.GetComponent<WeaponBase>();
        }

    }
}
