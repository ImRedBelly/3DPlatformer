using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    [Header("Movement config")]
    [SerializeField] private CharacterController controller;
    public Vector3 startPosition;
    bool isMove= true;
    
    [Header("Rotation config")]
    [SerializeField] private float rotationSpeed = 1000;


    [Header("References")]
    [SerializeField] private float speed = 10;

    [Header("Gravity")]
    [SerializeField] private float jumpHeight = 10;  
    [SerializeField] private float gravityScale = 10;

    private float gravity;

    private void Awake()
    {
        startPosition = transform.position;
        
    }
    private void Start()
    {
        if(instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;
    }
    void Update()
    {
        if (isMove)
        {
            Rotate();
            Move();
        }
        

        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
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
    public void Restart()
    {
        StartCoroutine(StopMove());
        transform.position = startPosition;
    }
    public void Teleportation(GameObject endPoint)
    {
        StartCoroutine(StopMove());
        transform.position = endPoint.transform.position;
    }
    IEnumerator StopMove()
    {
        isMove = false;
        yield return new WaitForSeconds(.1f);
        isMove = true;
    }





    

}
