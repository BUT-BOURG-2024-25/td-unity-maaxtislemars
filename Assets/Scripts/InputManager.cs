using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    [SerializeField]
    private InputActionReference movementAction = null;

    [SerializeField]
    private InputActionReference JumpAction = null;

    [SerializeField]
    private InputActionReference MouseClickAction = null;

    public static InputManager instance {  get { return _instance; } }

    private static InputManager _instance = null;

    public Vector3 movementInput {  get; private set; }

    private void Awake()
    {
        if(_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void registerOnJumpInput(Action<InputAction.CallbackContext> OnJumpAction, bool register)
    {
        if (register) {
            JumpAction.action.performed += OnJumpAction;
        }
        else
        {
            JumpAction.action.performed -= OnJumpAction;
        }
    }

    public void registerOnMouseClick(Action<InputAction.CallbackContext> OnMouseClickAction, bool register)
    {
        if (register)
        {
            MouseClickAction.action.performed += OnMouseClickAction;
        }
        else
        {
            MouseClickAction.action.performed -= OnMouseClickAction;
        }
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 moveInput = movementAction.action.ReadValue<Vector2>();
        movementInput = new Vector3(moveInput.x, 0, moveInput.y);

    }

}
