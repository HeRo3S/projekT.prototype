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
    //Inventory
    [SerializeField]
    private Inventory inventory;
    [SerializeField]
    protected int budget;
    //Targeting
    public GameObject target;
    //Phasing
    private Collider2D collisionBorder;
    bool endingPhasing = false;
    //Audio Manager
    private AudioManager audioManager;
    //Interacting
    private List<IIteractable> interactList = new List<IIteractable>();

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
        //Inventory initialize
        InstanceManager.Instance.currentInventory = inventory;
        SaveSystem.Load();
        //Phasing
        collisionBorder = transform.GetChild(1).GetComponent<Collider2D>();
    }
    public void Start()
    {
        //Audio Manager
        //audioManager = InstanceManager.Instance.audioManager;
        audioManager = AudioManager.Instance;
    }

    public void FixedUpdate()
    {
        stamina = Mathf.Min(maxStamina, stamina + staminaRegen*Time.fixedDeltaTime);
        if (endingPhasing)
        {
            EndPhasing();
        }
    }
    public void Update()
    {
        anim.SetFloat("LatestAngle", SplitRotationAngleInto(4));
    }
    public override bool Move(Vector2 moveDirection)
    {
        if (!inAttackAnimation)
        {
            base.Move(moveDirection);
        }
        //animation
        anim.SetBool("IsRunning", moveVector != Vector2.zero);
        //audio
        if (moveVector == Vector2.zero)
        {
            audioManager.Stop("player_run_grass");
        }
        else
        {
            audioManager.LoopAudioInUpdateFunction("player_run_grass");
        }

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

    //Adjust recovery stats algorithm
    public virtual void AdjustMana(float amount)
    { 
        mana = Mathf.Clamp(mana +amount, 0, maxMana);
    }
    public virtual void AdjustStamina(float amount)
    { 
        stamina = Mathf.Clamp(stamina +amount, 0, maxStamina);
    }
    //Consume recovery stats
    public void ConsumeStamina(float value)
    {
        AdjustStamina(-value);
    }
    public void ConsumeMana(float value)
    {
        AdjustMana(-value);
    }
    //Recover recovery stats
    public void Heal(float value)
    {
        AdjustHealth(value);
    }
    public void RefillMana(float value)
    {
        AdjustMana(value);
    }
    public void RefillStamina(float value)
    {
        AdjustStamina(value);
    }

    //Getter, setter
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
    public int GetBudget()
    {
        return budget;
    }
    public void SpendBudget(int value)
    {
        budget -= value;
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

    public override void SelfDestruct()
    {
        CanvasController.GetInstance().EnableOnlyCanvas("DiedDialogue");
        base.SelfDestruct();
    }

    //Phasing make player ignore all collision
    public void StartPhasing()
    {
        gameObject.layer = LayerMask.NameToLayer("Phasing");
        collisionBorder.isTrigger = true;
    }

    public void EndPhasing()
    {
        //Find a suitable position before ending phasing
        Collider2D[] dumpResult = new Collider2D[1];
        collisionBorder.OverlapCollider(InstanceManager.Instance.groundEntityFilter, dumpResult);
        if(dumpResult[0] != null)
        {
            inAttackAnimation = true;
            Move(direction);
            endingPhasing = true;
        }
        else
        {
            endingPhasing = false;
            inAttackAnimation = false;
            Move(Vector2.zero);
            gameObject.layer = LayerMask.NameToLayer("Player");
            collisionBorder.isTrigger = false;
        }
    }
    
    //Interacting
    public void Interact()
    {
        if (interactList.Count == 0)
        {
            Debug.Log("Invalid Request");
            return;
        }
        IIteractable closestTarget = interactList[0];
        float shortestDistance = (((MonoBehaviour)closestTarget).transform.position - transform.position).magnitude;
        foreach (IIteractable target in interactList)
        {
            float distance = (((MonoBehaviour)target).transform.position - transform.position).magnitude;
            if (distance < shortestDistance)
            {
                closestTarget = target;
                shortestDistance = distance;
            }
        }
        closestTarget.OnInteract();
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        IIteractable collideEntity = collision.gameObject.GetComponent<IIteractable>();
        if(collideEntity != null)
        {
            interactList.Add(collideEntity);
            InstanceManager.Instance.interactButton.gameObject.SetActive(true);
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        IIteractable collideEntity = collision.gameObject.GetComponent<IIteractable>();
        if (collideEntity != null)
        {
            interactList.Remove(collideEntity);
            if(interactList.Count == 0)
            {
                InstanceManager.Instance.interactButton.gameObject.SetActive(false);
            }
        }
    }
}
