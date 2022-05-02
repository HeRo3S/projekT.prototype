using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GolemAttack : EntityBase 
{
    public virtual void OnTriggerEnter2D(Collider2D collision)
    {
        Player player = collision.GetComponent<Player>();
        if (player != null)
        {
            player.TakeDamage(69);
        }
    }
    public void AfterAnimation()
    {
        Destroy(gameObject);
    }
}
