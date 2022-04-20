using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class TestWeapon : MonoBehaviour
{
    private HashSet<EnemyBase> hitList = new HashSet<EnemyBase>();
    Animator anim;
    private Player player;

    public void Start()
    {
        //setup animation controller
        PlayerInputSystem weaponInput = new PlayerInputSystem();
        weaponInput.Player.LightAttack.Enable();
        weaponInput.Player.LightAttack.performed += LightAttack_performed;
        anim = gameObject.GetComponent<Animator>();
        player = InstanceManager.Instance.player.GetComponent<Player>();
    }

    private void LightAttack_performed(InputAction.CallbackContext obj)
    {
        anim.SetTrigger("LightAttack");
        player.ConsumeStamina(100);
        
    }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        EnemyBase hitEntity = collision.gameObject.GetComponent<EnemyBase>();
        if (hitEntity != null)
        {
            if (!hitList.Contains(hitEntity))
            {
                hitList.Add(hitEntity);
                hitEntity.TakeDamage(100);
            }
        }
    }
    public void OnTriggerExit2D(Collider2D collision)
    {
        EnemyBase hitEntity = collision.gameObject.GetComponent<EnemyBase>();
        if (hitEntity != null)
        {
            if (hitList.Contains(hitEntity))
            {
                hitList.Remove(hitEntity);
                hitEntity.GetComponent<SpriteRenderer>().color = Color.yellow;
            }
        }
    }

}
