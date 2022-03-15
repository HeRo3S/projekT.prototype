using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class TestWeapon : MonoBehaviour
{
    private HashSet<GameObject> hitList = new HashSet<GameObject>();
    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hitEntity = collision.gameObject;
        if (hitEntity.CompareTag("Enemy"))
        {
            Debug.Log("HIT");
            if (!hitList.Contains(hitEntity))
            {
                hitList.Add(hitEntity);
                hitEntity.GetComponent<SpriteRenderer>().color = Color.red;
            }
        }
    }
    public void OnCollisionExit2D(Collision2D collision)
    {
        GameObject hitEntity = collision.gameObject;
        if (hitEntity.CompareTag("Enemy"))
        {
            if (hitList.Contains(hitEntity))
            {
                hitList.Remove(hitEntity);
                hitEntity.GetComponent<SpriteRenderer>().color = Color.yellow;
            }
        }
    }
}
