using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement config")]
    [SerializeField] private CharacterController controller;
    
    [Header("Rotation config")]
    [SerializeField] private float rotationSpeed = 1000;


    [Header("References")]
    [SerializeField] private float speed = 10;

    [Header("Gravity")]
    [SerializeField] private float jumpHeight = 10;  
    [SerializeField] private float gravityScale = 10;

    private float gravity;
    void Update()
    {
        Rotate();
        Move();
    }

    private void Move()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");

        Vector3 moveDirection = transform.forward * inputV + transform.right * inputH;







        if (controller.isGrounded)
        {
            gravity = -0.1f;
            if (Input.GetButtonDown("Jump"))
            {
                gravity = jumpHeight;
            }
        }
        else
        {
            gravity += gravityScale * Physics.gravity.y * Time.deltaTime;
        }

        if (moveDirection.magnitude > 1)
        {
            moveDirection.Normalize();
        }


        moveDirection.y = gravity;
        controller.Move(moveDirection * speed * Time.deltaTime);
    }


    private void Rotate()
    {
        float mouseHorizoltal = Input.GetAxis("Mouse X");

        transform.Rotate(Vector3.up, mouseHorizoltal * rotationSpeed * Time.deltaTime);
    }
}
