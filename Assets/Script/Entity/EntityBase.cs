using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class EntityBase : MonoBehaviour, IMovable
{
    //Stat related value
    [SerializeField]
    protected float maxHealth;
    [SerializeField]
    protected float healthPts;
    [SerializeField]
    protected float speed;
    //Damage frame related value
    protected readonly int damageFrame = 3;
    protected int currentDamageFrame;
    protected readonly int invincibleFrame;
    protected int currentIFrame;
    //GameObject component mapping
    protected Rigidbody2D rBody;
    //Movement
    protected Vector2 moveVector;

    //direction only used to calculate rotation and won't be update if rotation get modified
    protected float rotation;
    protected Vector2 direction;

    //Status (sorta)
    public bool inAttackAnimation;

    //Animator
    [SerializeField]
    protected Animator anim;
    public virtual void Awake()
    {
        rBody = gameObject.GetComponent<Rigidbody2D>();
        direction = new Vector2(1f, 0f);
    }


    //Start damage frame (damaged indicator)
    protected void StartDamageFrame()
    {
        if (currentDamageFrame <= 0)
        {
            currentDamageFrame = damageFrame;
        }
    }
    public void TakeDamage(float damage)
    {
        StartDamageFrame();
        healthPts -= damage;
        Vector3 popUpPos = new Vector3( transform.position.x + Random.Range(-1.5f, 1.5f),
                                        transform.position.y + Random.Range(-1.5f, 1.5f),
                                        transform.position.z);
        TextPopUp.Create(((int)damage).ToString(), popUpPos, 30);
        DestructWhenDead();
    }

    public virtual void SelfDestruct()
    {
        Destroy(gameObject);
    }

    public virtual void DestructWhenDead()
    {
        if (healthPts <= 0) { SelfDestruct(); }
    }

    public virtual bool Move(Vector2 moveDirection)
    {   
        //Check if move vector have changed
        if (moveVector != moveDirection * speed)
        {
            moveVector = moveDirection * speed;
            rBody.velocity = moveVector;
            UpdateRotation();
        }
        return true;
    }

    public virtual void UpdateRotation()
    {
        if (moveVector != Vector2.zero)
        {
            direction = moveVector / moveVector.magnitude;
        }
        rotation = (float)(System.Math.Atan2(direction.y, direction.x) / System.Math.PI * 180f);
    }
    public float GetHealth()
    {
        return healthPts;
    }
    public float GetMaxHP()
    {
        return maxHealth;
    }

    public float GetRotation()
    {
        return rotation;
    }
    public float SplitRotationAngleInto(int howManyParts)
    {
        //eachPartVolumne: the range each part hold
        //  ex: for each part of 8 would hold 360/8 = 45 degree
        //      for each part of 4 would hold 360/4 = 90 degree
        int eachPartVolume = 360 / howManyParts;

        //the result will be in the range of int:[-biggestValueAfterRounded; biggestValueAfterRounded]
        float biggestValueAfterRounded = howManyParts / 2f;

        //we need to divide current rotation by eachPartVolume so we can roundup every angle that in-between 2 part.
        //we divide by biggestValueAfterRounded to return the value in float:[-1;1] range 
        return Mathf.RoundToInt(GetRotation() / eachPartVolume) / biggestValueAfterRounded; 
    }

    public void SetRotation(float value)
    {
        rotation = Mathf.Clamp(value,-180,180);
    }
    public Vector2 GetDirection()
    {
        return direction;
    }
}
