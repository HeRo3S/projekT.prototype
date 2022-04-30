using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    //General Component
    private PlayerInputSystem playerInputSystem;
    private Camera mainCam;
    private Player player;
    //Movement
    private Vector2 moveVector;
    private bool moving;
    //private ContactFilter2D moveFilter;
    //private readonly float collisionOffset = 0.05f;
    //Target Lock
    [SerializeField]
    private GameObject pfTargetIndicator;
    private GameObject targetIndicator;
    [SerializeField]
    private float targetRadius;
    private GameObject target;
    //Rotation
    private Vector2 targetRotationLocation;
    private float rotation;
    private void Start()
    {
        //Get component
        player = InstanceManager.Instance.player;
        mainCam = Camera.main;
        //Active input
        playerInputSystem = new PlayerInputSystem();
        playerInputSystem.Player.Enable();
        playerInputSystem.Player.Move.performed += Move_performed;
        playerInputSystem.Player.Move.canceled += Move_canceled;
        playerInputSystem.Player.Move.started += Move_started;
        playerInputSystem.Player.LockTarget.performed += LockTarget_performed;
        playerInputSystem.Player.ReleaseLock.performed += ReleaseLock_performed;
        playerInputSystem.Player.LightAttack.performed += LightAttack_performed;
        playerInputSystem.Player.SwitchWeapon.performed += SwitchWeapon_performed;
        //Initialize Value
        moveVector.Set(0f, 0f);
        targetRotationLocation.Set(0f, 0f);
        //moveFilter = InstanceManager.Instance.groundEntityFilter;
    }

    private void SwitchWeapon_performed(InputAction.CallbackContext obj)
    {
        player.SwitchNextWeapon();
    }

    private void LightAttack_performed(InputAction.CallbackContext obj)
    {
        moving = false;
        FixedUpdate();
        player.GetCurrentWeapon().DoAttack();
        moving = true;
    }

    private void ReleaseLock_performed(InputAction.CallbackContext context)
    {
        target = null;
        if(targetIndicator != null)
        {
            targetIndicator.SetActive(false);
        }

    }

    //Subcribe to event
    private void LockTarget_performed(InputAction.CallbackContext context)
    {
        //Read touch input and convert to world position
        Vector2 touchPos = context.ReadValue<Vector2>();
        Vector2 targetLocation = mainCam.ScreenToWorldPoint(new Vector3(touchPos.x, touchPos.y));
        foreach (Collider2D collider in Physics2D.OverlapCircleAll(targetLocation, targetRadius))
        {
            if (collider != null && collider.gameObject.GetComponent<ITargetable>() != null)
            {
                if(targetIndicator == null)
                {
                    targetIndicator = Instantiate(pfTargetIndicator);
                }
                targetIndicator.SetActive(true);
                target = collider.gameObject;
                targetIndicator.transform.SetParent(target.transform, false);
                break;
            }
        }

    }

    private void Move_started(InputAction.CallbackContext context)
    {
        moving = true;
    }

    //Stop when no input
    private void Move_canceled(InputAction.CallbackContext context)
    {
        moveVector.Set(0f, 0f);
        moving = false;
    }

    //Get input direction
    private void Move_performed(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>();
        moveVector.Set(inputVector.x, inputVector.y);
    }

    private void FixedUpdate()
    {
        //Calculate rotation angle
        if (moving)
        {
            targetRotationLocation = moveVector;
        }
        else
        {
            if (target != null)
            {
                targetRotationLocation = target.transform.position - transform.position;
            }
        }
        rotation = (float)(System.Math.Atan2(targetRotationLocation.y, targetRotationLocation.x) / System.Math.PI * 180f);
        player.Move(moveVector);
        player.SetRotation(rotation);
    }



}
