using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ProjectileBase : EntityBase
{
    protected int frameToLive;
    public virtual void InitValue(Vector2 direction, float speed, float rotation, int frameToLive)
    {
        this.speed = speed;
        this.rotation = rotation;
        Move(direction);
        rBody.MoveRotation(rotation - 90);
        this.frameToLive = frameToLive;
    }

    public virtual void FixedUpdate()
    {
        if(frameToLive <= 0)
        {
            Destroy(gameObject);
        }
        frameToLive--;
    }

}
