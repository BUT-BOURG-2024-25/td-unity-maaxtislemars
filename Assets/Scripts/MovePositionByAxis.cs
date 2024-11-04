using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovePositionByAxis : MonoBehaviour
{
    [SerializeField]
    private float speed = 1f;
    [SerializeField]
    private float jumpPower = 2000.0f;
    [SerializeField]
    private Rigidbody physicsBody;


    private void Start()
    {
        InputManager.instance.registerOnJumpInput(Jump, true);
    }

    private void OnDestroy()
    {
        InputManager.instance.registerOnJumpInput(Jump, false);
    }

    void Update()
    {
        Vector3 newVelocity = InputManager.instance.movementInput * speed;
        newVelocity.y = physicsBody.velocity.y;

        physicsBody.velocity =  newVelocity;

    }

    private void Jump(InputAction.CallbackContext callbackContext)
    {
        physicsBody.AddForce(Vector3.up * jumpPower);
    }


}
