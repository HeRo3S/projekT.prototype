using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rigidBody;
    private readonly float speed = 4.5f;
    private PlayerInputSystem playerInputSystem;
    private Vector2 moveVector;
    private Vector2 lastMoveVector;
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
        if(moveVector != lastMoveVector)
        {
            rigidBody.velocity = moveVector * speed;
            lastMoveVector = moveVector;
            Debug.Log(moveVector);
        }

    }
}
