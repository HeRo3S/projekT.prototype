using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shopkeeper: EntityBase 
{
    [SerializeField]
    private Inventory inventory;
    protected float detectionRange = 8f;
    private GameObject target;

    public override void Awake()
    {
        base.Awake();
        anim = gameObject.GetComponent<Animator>();
    }

    public void Start()
    {
        GetTarget();
        speed = 0f;
    }

    public void GetTarget()
    {
        target = InstanceManager.Instance.player.gameObject;
    }
    // Update is called once per frame
    public void FixedUpdate()
    {
        Vector2 moveDirection = target.transform.position - transform.position;
        if (moveDirection.magnitude <= detectionRange)
        {
            moveDirection /= moveDirection.magnitude;
            Move(moveDirection);
            anim.SetFloat("LatestAngle", SplitRotationAngleInto(4));
        }
    }
    public override bool Move(Vector2 moveDirection)
    {   
        //Check if move vector have changed
        //if (rBody.velocity != moveDirection * speed)
        //{
            moveVector = moveDirection;
            //rBody.velocity = moveVector;
            UpdateRotation();
        //}
        return true;
    }
    public Inventory GetInventory()
    {
        return inventory;
    }

}
