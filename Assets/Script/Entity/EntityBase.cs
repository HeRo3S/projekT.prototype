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
    public void TakeDamage(int damage)
    {
        StartDamageFrame();
        Vector3 popUpPos = new Vector3( transform.position.x + Random.Range(-1.5f, 1.5f),
                                        transform.position.y + Random.Range(-1.5f, 1.5f),
                                        transform.position.z);
        TextPopUp.Create(damage.ToString(),popUpPos , 30);
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

    //calculate and roundup rotation angle into 8 fixed angles only
    public float SplitRotationAngleInto4()
    {
        //rotation value is in the range [-180;180]
        //discreet transform all the rotation value into 8 values below:
        // [-135    -i90    -45  0   45   90   135   180]
        // [   -3    -2     -1  0    1    2     3     4]: divided by 45 to get the int number
        // [-0.75  -0.5  -0.25  0 0.25  0.5  0.75     1]: divided by 4 to get the float number in the range [-1;1]
        return Mathf.RoundToInt(GetRotation() / 45) / 4.0f;
    }

    public float SplitRotationAngleInto8()
    {
        return Mathf.RoundToInt(GetRotation() / 90) / 2.0f;
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
