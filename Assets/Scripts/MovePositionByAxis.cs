using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Diagnostics;
using System.Security.Cryptography;
using UnityEngine;

public class MovePositionByAxis : MonoBehaviour
{
    [SerializeField]
    private float speed = 0.1f;

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        UnityEngine.Debug.Log("Horizontal :" + horizontal);
        UnityEngine.Debug.Log("Vertical :" + vertical);

        Vector3 movement = new Vector3(horizontal, 0, vertical);

        gameObject.transform.position += speed*movement;
    }
}
