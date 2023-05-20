using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float movementSpeed = 10.0f;
    [SerializeField] private float rotationSpeed = 50.0f;
    [SerializeField] private float jumpForce = 100.0f;

    private float verticalInput;
    private float horizontalInput;
    private GameObject mainCamera;

    Rigidbody rb;
    private void Awake()
    {
        mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
        rb = GetComponent<Rigidbody>();
    }
    void Start()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        }
    }

    private void Update()
    {
        verticalInput = Input.GetAxis("Vertical");
        horizontalInput = Input.GetAxis("Horizontal");
    }
    // Update is called once per frame
    void FixedUpdate()
    {

        rb.AddRelativeForce(Vector3.forward * verticalInput * movementSpeed );
        transform.Rotate(Vector3.up, rotationSpeed * horizontalInput * Time.deltaTime);
    }
}
