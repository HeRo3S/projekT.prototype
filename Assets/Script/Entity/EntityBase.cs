using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EntityBase : MonoBehaviour, ITargetable
{
    //Stat related value
    protected int maxHealth;
    protected int healthPts;
    //Damage frame related value
    protected readonly int damageFrame = 3;
    protected int currentDamageFrame;
    protected readonly int invincibleFrame;
    protected int currentIFrame;

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

}
