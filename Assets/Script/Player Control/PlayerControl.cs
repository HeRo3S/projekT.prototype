using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private readonly float speed = 6f;
    private PlayerInputSystem playerInputSystem;
    private Vector2 moveVector;
    [SerializeField]
    private ContactFilter2D moveFilter;
    [SerializeField]
    private float collisionOffset = 0.1f;
    private void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerInputSystem = new PlayerInputSystem();
        playerInputSystem.Player.Enable();
        playerInputSystem.Player.Move.performed += Move_performed;
        playerInputSystem.Player.Move.canceled += Move_canceled;
    }

    private void Move_canceled(InputAction.CallbackContext context)
    {
        moveVector.Set(0f, 0f);
    }

    private void Move_performed(InputAction.CallbackContext context)
    {
        Vector2 inputVector = context.ReadValue<Vector2>();
        float inputVectorMag = inputVector.magnitude;
        moveVector.Set(inputVector.x / inputVectorMag, inputVector.y / inputVectorMag);
    }

    private void FixedUpdate()
    {
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
