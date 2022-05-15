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
    private void Awake()
    {
        //Get component
        player = InstanceManager.Instance.player;
        mainCam = InstanceManager.Instance.mainCamera;
        //Active input
        playerInputSystem = InstanceManager.Instance.inputSystem;
        playerInputSystem.Player.Enable();
        playerInputSystem.Player.Move.performed += Move_performed;
        playerInputSystem.Player.Move.canceled += Move_canceled;
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
        player.GetCurrentWeapon().DoAttack();
    }

    private void ReleaseLock_performed(InputAction.CallbackContext context)
    {
        target = null;
        player.target = null;
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
                player.target = target;
                player.UpdateRotation();
                targetIndicator.transform.SetParent(target.transform, false);
                break;
            }
        }

    }

    //Stop when no input
    private void Move_canceled(InputAction.CallbackContext context)
    {
        moveVector = Vector2.zero;
    }

    //Get input direction
    private void Move_performed(InputAction.CallbackContext context)
    {
        moveVector = context.ReadValue<Vector2>();
    }
    public void Update()
    {
        player.Move(moveVector);
    }

    //Clean up
    public void OnDisable()
    {
        //Unsubcribe from all event
        playerInputSystem.Player.Move.performed -= Move_performed;
        playerInputSystem.Player.Move.canceled -= Move_canceled;
        playerInputSystem.Player.LockTarget.performed -= LockTarget_performed;
        playerInputSystem.Player.ReleaseLock.performed -= ReleaseLock_performed;
        playerInputSystem.Player.LightAttack.performed -= LightAttack_performed;
        playerInputSystem.Player.SwitchWeapon.performed -= SwitchWeapon_performed;
    }

}
