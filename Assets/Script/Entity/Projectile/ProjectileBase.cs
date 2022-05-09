using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileBase : EntityBase
{
    protected float timeToLive;
    public virtual void InitValue(float speed, float rotation, float timeToLive)
    {
        this.speed = speed;
        this.rotation = rotation;
        float rAngle = rotation * Mathf.Deg2Rad;
        Move(new Vector2(Mathf.Cos(rAngle), Mathf.Sin(rAngle)));
        //Caliberate rotation cuz sprite placement :shrug:
        rBody.MoveRotation(rotation - 90);
        this.timeToLive = timeToLive;
    }

    public virtual void FixedUpdate()
    {
        if(timeToLive <= 0)
        {
            Destroy(gameObject);
        }
        timeToLive -= Time.fixedDeltaTime;
    }

}
