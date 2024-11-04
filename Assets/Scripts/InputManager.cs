using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{

    [SerializeField]
    private InputActionReference movementAction = null;

    // Update is called once per frame
    void Update()
    {
        Vector2 movementInput = movementAction.action.ReadValue<Vector2>();


    }
}
