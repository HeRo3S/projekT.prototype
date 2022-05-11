using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : ProjectileBase
{
    protected float damage = 69;
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBase hitEntity = collision.gameObject.GetComponent<EnemyBase>();
        if (hitEntity != null)
        {
            hitEntity.TakeDamage(damage);
            FindObjectOfType<AudioManager>().Play("arrow_hit");
            Destroy(gameObject);
        }
    }
    public void InitValue(float speed, float rotation, float timeToLive, float damage)
    {
        base.InitValue(speed, rotation, timeToLive);
        this.damage = damage;
    }
}
