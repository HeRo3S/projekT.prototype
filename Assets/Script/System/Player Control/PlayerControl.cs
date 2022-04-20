using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    //General Component
    private Rigidbody2D rigidBody;
    private PlayerInputSystem playerInputSystem;
    private Camera mainCam;
    //Movement
    private readonly float speed = 6f;
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
    private float lastRotation;
    private readonly float rotateSpeed = 15;
    //Animator
    public Animator anim;
    private void Awake()
    {
        //Register to manager
        InstanceManager.Instance.player = gameObject;
        //Get component
        rigidBody = GetComponent<Rigidbody2D>();
        mainCam = Camera.main;
        //Active input
        playerInputSystem = new PlayerInputSystem();
        playerInputSystem.Player.Enable();
        playerInputSystem.Player.Move.performed += Move_performed;
        playerInputSystem.Player.Move.canceled += Move_canceled;
        playerInputSystem.Player.Move.started += Move_started;
        playerInputSystem.Player.LockTarget.performed += LockTarget_performed;
        playerInputSystem.Player.ReleaseLock.performed += ReleaseLock_performed;
        //Initialize Value
        moveVector.Set(0f, 0f);
        targetRotationLocation.Set(0f, 0f);
        //moveFilter = InstanceManager.Instance.groundEntityFilter;
    }

    private void ReleaseLock_performed(InputAction.CallbackContext context)
    {
        target = null;
        targetIndicator.SetActive(false);
    }

    //Subcribe to event
    private void LockTarget_performed(InputAction.CallbackContext context)
    {
        Debug.Log(context);
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
        float inputVectorAbs = Mathf.Abs(inputVector.x) + Mathf.Abs(inputVector.y);
        moveVector.Set(inputVector.x / inputVectorAbs, inputVector.y / inputVectorAbs);
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

        //Rotating to target point
        //Rotate();
        //Move
        if (!Move(moveVector))
        {
            if(!Move(new Vector2(moveVector.x, 0)))
            {
                Move(new Vector2(0, moveVector.y));
            }
        }
    }


    private bool Move(Vector2 moveVector)
    {
        //int count = rigidBody.Cast(
        //    moveVector,
        //    moveFilter,
        //    new List<RaycastHit2D>(),
        //    speed * Time.fixedDeltaTime + collisionOffset);
        //if (count == 0)
        //{
        //    rigidBody.MovePosition(rigidBody.position + speed * Time.fixedDeltaTime * moveVector);
        //    return true;
        //}
        //return false;
        rigidBody.velocity = moveVector * speed;
        //animation setup
        anim.SetFloat("SpeedX", moveVector.x);
        anim.SetFloat("SpeedY", moveVector.y);

        return true;
    }

    private void Rotate()
    {
        rotation = (float)(System.Math.Atan2(targetRotationLocation.x, targetRotationLocation.y) / System.Math.PI * -180f);
        rotation += 90;
        if (rotation < 0)
        {
            rotation += 360;
        }
        if (rotation != lastRotation)
        {
            float moveTo;
            if (rigidBody.rotation > rotation)
            {
                if (rigidBody.rotation - rotation > 180)
                {
                    moveTo = rigidBody.rotation + rotateSpeed;
                    if (moveTo > 360 + rotation)
                    {
                        moveTo = rotation;
                    }

                }
                else
                {
                    moveTo = rigidBody.rotation - rotateSpeed;
                }
                rigidBody.MoveRotation(Mathf.Max(moveTo, rotation));
            }
            if (rigidBody.rotation < rotation)
            {
                if (rotation - rigidBody.rotation > 180)
                {
                    moveTo = rigidBody.rotation - rotateSpeed;
                    if (moveTo < rotation - 360)
                    {
                        moveTo = rotation;
                    }

                }
                else
                {
                    moveTo = rigidBody.rotation + rotateSpeed;
                }
                rigidBody.MoveRotation(Mathf.Min(moveTo, rotation));
            }
            if (rigidBody.rotation > 360)
            {
                rigidBody.rotation -= 360;
            }
            if (rigidBody.rotation < 0)
            {
                rigidBody.rotation += 360;
            }
            lastRotation = rigidBody.rotation;
        }


    }
}
