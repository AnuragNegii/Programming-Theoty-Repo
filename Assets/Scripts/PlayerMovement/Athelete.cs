using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Athelete : PlayerMovement
{

    private void Awake()
    {
        rigidBodyRB = GetComponent<Rigidbody>();
        MovementSpeed = 700.0f;
        JumpForce = 1000.0f;
    }

    void Update()
    {
        jumpMethod();
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }

    private void jumpMethod()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rigidBodyRB.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);

        }
    }

    private void FixedUpdate()
    {
        rigidBodyRB.AddRelativeForce(Vector3.forward * verticalInput * MovementSpeed);
        transform.Rotate(Vector3.up, rotationSpeed * horizontalInput * Time.deltaTime);
    }
}
