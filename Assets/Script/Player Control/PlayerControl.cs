using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private PlayerInputSystem playerInputSystem;
    //Movement
    private readonly float speed = 6f;
    private Vector2 moveVector;
    private bool moving;
    //Target Lock
    [SerializeField]
    private GameObject target;
    //Rotation
    private Vector2 targetRotationLocation;
    private float rotation;
    private float lastRotation;
    private readonly float rotateSpeed = 15;
    [SerializeField]
    private ContactFilter2D moveFilter;
    [SerializeField]
    private float collisionOffset = 0.1f;
    private void Awake()
    {
        //Get component
        rigidBody = GetComponent<Rigidbody2D>();

        //Active input
        playerInputSystem = new PlayerInputSystem();
        playerInputSystem.Player.Enable();
        playerInputSystem.Player.Move.performed += Move_performed;
        playerInputSystem.Player.Move.canceled += Move_canceled;
        playerInputSystem.Player.Move.started += Move_started;
        //Initialize rotation
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
        float inputVectorMag = inputVector.magnitude;
        moveVector.Set(inputVector.x / inputVectorMag, inputVector.y / inputVectorMag);
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



        //Rotating to predefined angle
        rotation = (float)(System.Math.Atan2(targetRotationLocation.x, targetRotationLocation.y) / System.Math.PI * -180f);
        rotation += 90;
        if (rotation < 0)
        {
            rotation += 360;
        }
        if(rotation != lastRotation)
        {
            float moveTo;
            if(rigidBody.rotation > rotation)
            {
                if(rigidBody.rotation - rotation > 180)
                {
                    moveTo = rigidBody.rotation + rotateSpeed;
                    if(moveTo > 360 + rotation)
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
            if(rigidBody.rotation < rotation)
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
        int count = rigidBody.Cast(
            moveVector,
            moveFilter,
            new List<RaycastHit2D>(),
            speed * Time.fixedDeltaTime + collisionOffset);
        if (count == 0)
        {
            rigidBody.MovePosition(rigidBody.position + speed * Time.fixedDeltaTime * moveVector);
            return true;
        }
        return false;
    }
}
