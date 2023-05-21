using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 700.0f;
    public float MovementSpeed{ get { return movementSpeed; }set { movementSpeed = value; } }
    [SerializeField] protected float rotationSpeed = 50.0f;
    [SerializeField] private float jumpForce = 1000.0f;
    protected float JumpForce{get {return jumpForce; }set { jumpForce = value; }}

    private float verticalInput;
    private float horizontalInput;

    Rigidbody rigidBodyRB;
    private void Awake()
    {
        rigidBodyRB = GetComponent<Rigidbody>();
    }
    private void Update()
    {
        jumpMethod(rigidBodyRB, jumpForce);
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }

    protected void jumpMethod(Rigidbody rb, float jumpForce)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigidBodyRB.AddRelativeForce(Vector3.forward * verticalInput * movementSpeed );
        transform.Rotate(Vector3.up, rotationSpeed * horizontalInput * Time.deltaTime);
    }
}
