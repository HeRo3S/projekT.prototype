using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class TestWeapon : MonoBehaviour
{
    private HashSet<GameObject> hitList = new HashSet<GameObject>();
    Animator anim;


    public void Start()
    {
        //setup animation controller
        PlayerInputSystem weaponInput = new PlayerInputSystem();
        weaponInput.Player.LightAttack.Enable();
        weaponInput.Player.LightAttack.performed += LightAttack_performed;
        anim = gameObject.GetComponent<Animator>();
    }

    private void LightAttack_performed(InputAction.CallbackContext obj)
    {
        anim.SetTrigger("LightAttack");
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        GameObject hitEntity = collision.gameObject;
        if (hitEntity.CompareTag("Enemy"))
        {
            if (!hitList.Contains(hitEntity))
            {
                hitList.Add(hitEntity);
                hitEntity.GetComponent<EntityBase>().TakeDamage(100);
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
