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
        InputManager.instance.registerOnMouseClick(spawnCube, true);
    }

    private void OnDestroy()
    {
        InputManager.instance.registerOnMouseClick(spawnCube, false);
    }

    private void spawnCube(InputAction.CallbackContext callbackContext)
    {
        Ray cameraRay = Camera.main.ScreenPointToRay(Input.mousePosition);

        //Debug.DrawRay(cameraRay.origin, cameraRay.di)

        RaycastHit hitInfo;

        bool raycastHasHit = Physics.Raycast(cameraRay, out hitInfo, 10000,GroundLayer);

        if (raycastHasHit && objectToSpawn != null)
        {
            GameObject.Instantiate(objectToSpawn, hitInfo.point, Quaternion.identity);

        }

    }

    void Update()
    {

    }

}
