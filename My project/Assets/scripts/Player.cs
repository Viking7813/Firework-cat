using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public Rigidbody rb;

    public Transform playerbody;

    float xRotation = 0f;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float hi = Input.GetAxis("Horizontal");
        float vi = Input.GetAxis("Vertical");

        float mouseX = Input.GetAxis("Mouse X") * 5f;
        float mouseY = Input.GetAxis("Mouse Y") * 5f;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        playerbody.Rotate(Vector3.up * mouseX);
    }
}