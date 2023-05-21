using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Child : PlayerMovement
{
    private float verticalInput;
    private float horizontalInput;
    Rigidbody rigidBodyRB;
    private void Awake()
    {
        rigidBodyRB = GetComponent<Rigidbody>();
    }

    void Start()
    {
        MovementSpeed = 500.0f;
        JumpForce = 700.0f;
    }

    // Update is called once per frame
    void Update()
    {
        jumpMethod(rigidBodyRB, JumpForce);
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        rigidBodyRB.AddRelativeForce(Vector3.forward * verticalInput * MovementSpeed);
        transform.Rotate(Vector3.up, rotationSpeed * horizontalInput * Time.deltaTime);
    }
}
