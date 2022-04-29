using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : ProjectileBase
{
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBase hitEntity = collision.gameObject.GetComponent<EnemyBase>();
        if (hitEntity != null)
        {
            hitEntity.TakeDamage(69);
            Destroy(gameObject);
        }
    }
}
