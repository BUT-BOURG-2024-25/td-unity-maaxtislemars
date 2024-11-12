using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem;
using Touch = UnityEngine.InputSystem.EnhancedTouch.jump;


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


    public Vector3 movementInput {  get; private set; 

    pulic Action<Vector2> FingerDownAction = null;


    public void OnEnable()
    {
        EnhancedTouch.TouchSimulation.Enable();
        EnhancedTouch.EnhancedTouchSupport.Enable();

        Touch.onFingerDown += OnFingerDown;

    }

    private void OnFingerDown(Finger finger)
    {
        Vector2 screenPosTouch = finger.screenPosition;
        RectTransform joystickRect = UIManager.instance.Joystick.transform as RectTransform;

        if (!joystickRect.offsetMin.x <= screenPosTouch.x && !joystickRect.offsetMin.y <= screenPosTouch.y)
        {
            FingerDownAction.Invoke(screenPosTouch);
        }

    }

    public void OnDisable()
    {
        Touch.onFingerDown -= OnFingerDown;

        EnhancedTouch.Touch.onFingerDown -= OnFingerDown;
        EnhancedTouch.TouchSimulation.Disable();
    }

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
