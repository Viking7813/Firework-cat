using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public CharacterController characterController;

    public Transform GroundCheck;
    public LayerMask gmask;

    public float speed = 12f, gravity = -9.82f, groundDis = 0.4f;

    Vector3 velocity;

    bool grounded;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        grounded = Physics.CheckSphere(GroundCheck.position, groundDis, gmask);

        if (grounded && velocity.y < 0)
            velocity.y = -2f;

        float hi = Input.GetAxis("Horizontal");
        float vi = Input.GetAxis("Vertical");

        Vector3 move = transform.right * hi + transform.forward * vi;

        characterController.Move(move * speed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;

        characterController.Move(velocity * Time.deltaTime);
    }
}