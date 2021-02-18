using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement instance;

    [Header("Movement config")]
    [SerializeField] private CharacterController controller;
    public Vector3 startPosition;
    bool isMove = true;

    [Header("References")]
    [SerializeField] private float speed = 10;

    [Header("Gravity")]
    [SerializeField] private float jumpHeight = 10;
    [SerializeField] private float gravityScale = 10;

    private float gravity;

    public Camera mainCamera;

    private void Awake()
    {
        startPosition = transform.position;
    }

    private void Start()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }

        instance = this;

        mainCamera = Camera.main;
        Cursor.lockState = CursorLockMode.Locked;
    }
    void Update()
    {
        if (isMove)
            Move();



        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }

    private void Move()
    {
        float inputH = Input.GetAxis("Horizontal");
        float inputV = Input.GetAxis("Vertical");

        Vector3 forward = mainCamera.transform.forward;
        forward.y = 0;
        forward.Normalize();

        Vector3 right = mainCamera.transform.right;
        right.y = 0;
        right.Normalize();

        Vector3 moveDirection = forward * inputV + right * inputH;


        if (Mathf.Abs(inputH) > 0 || Mathf.Abs(inputV) > 0)
        {
            transform.rotation = Quaternion.LookRotation(moveDirection);
        }

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

        if (moveDirection.sqrMagnitude > 1)
        {
            moveDirection.Normalize();
        }


        moveDirection.y = gravity;
        controller.Move(moveDirection * speed * Time.deltaTime);
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
