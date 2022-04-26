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
        rBody.velocity = moveVector * speed;
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
        return (rotation / 180);
    }

    public void SetRotation(float value)
    {
        rotation = Mathf.Clamp(value,-180,180);
    }
}
