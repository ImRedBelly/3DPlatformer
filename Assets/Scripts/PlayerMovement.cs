using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float speed = 10f;

    [SerializeField]
    private float rotationSpeed = 1f;

    [SerializeField]
    private Rigidbody rb;


    void FixedUpdate()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        rb.AddForce(transform.forward * inputVertical * speed);

        transform.RotateAround(transform.position, Vector3.up, inputHorizontal * rotationSpeed);
    }
}
