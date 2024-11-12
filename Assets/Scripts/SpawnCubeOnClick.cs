using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.InputSystem;

public class SpawnCubeOnClick : MonoBehaviour
{
    [SerializeField]
    private GameObject objectToSpawn = null;

    [SerializeField]
    private LayerMask GroundLayer;



    private void Start()
    {
        InputManager.instance.registerOnMouseClick(spawnCubeByClick, true);
        InputManager.instance.FingerDownAction += OnFingerDown;
    }

    private void OnDestroy()
    {
        InputManager.instance.registerOnMouseClick(spawnCubeByClick, false);
        InputManager.instance.FingerDownAction -= OnFingerDown;
    }

    private void OnFingerDown(Vector2 screenPosition)
    {
        spawnCube(screenPosition);
    }

    private void spawnCubeByClick(InputAction.CallbackContext callbackContext)
    {
        spawnCube(Input.mousePosition);

    }
    private void spawnCube(Vector2 screenPosition)
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(screenPosition);

        RaycastHit hitInfo;

        bool raycastHasHit = Physics.Raycast(cameraRay, out hitInfo, 10000, GroundLayer);

        if (raycastHasHit && objectToSpawn != null)
        {
            GameObject.Instantiate(objectToSpawn, hitInfo.point, Quaternion.identity);

        }
    }

    void Update()
    {

    }

}
