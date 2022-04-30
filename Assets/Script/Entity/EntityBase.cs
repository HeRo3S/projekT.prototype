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
    //private ContactFilter2D moveFilter;
    //private readonly float collisionOffset = 0.05f;
    //Rendering
    protected float rotation;
    //Animator
    [SerializeField]
    protected Animator anim;
    public virtual void Awake()
    {
        rBody = gameObject.GetComponent<Rigidbody2D>();
        //moveFilter = InstanceManager.Instance.groundEntityFilter;
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

    public virtual bool Move(Vector2 moveVector)
    {
        //int count = rBody.Cast(
        //    moveVector,
        //    moveFilter,
        //    new List<RaycastHit2D>(),
        //    speed * Time.fixedDeltaTime + collisionOffset);
        //if (count == 0)
        //{
        //    rBody.MovePosition(rBody.position + speed * Time.fixedDeltaTime * moveVector);
        //    return true;
        //}
        //return false;
        if (rBody.velocity != moveVector * speed)
        {
            rBody.velocity = moveVector * speed;
        }
        return true;
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
        return ((int)GetRotation() / 45) / 4.0f;
    }

    public float SplitRotationAngleInto8()
    {
        return ((int)GetRotation() / 90) / 2.0f;
    }

    public void SetRotation(float value)
    {
        rotation = Mathf.Clamp(value,-180,180);
    }
    public Vector2 GetDirection()
    {
        float rAngle = rotation * Mathf.Deg2Rad;
        return new Vector2(Mathf.Cos(rAngle), Mathf.Sin(rAngle));
    }
}
