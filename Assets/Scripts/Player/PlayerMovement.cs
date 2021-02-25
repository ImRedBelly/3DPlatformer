using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{
    //TODO 
    // сделать смерть

    public static PlayerMovement instance;

    [Header("Movement config")]
    public Vector3 startPosition;
    bool isMove = true;

    [Header("References")]
    [SerializeField] private float speed = 10;
    [SerializeField] private float rotationSpeed = 10;

    [Header("Gravity")]
    [SerializeField] private float jumpHeight = 10;
    [SerializeField] private float gravityScale = 10;

    private float gravity;


    [Header("Movement config")]
    [SerializeField] private CharacterController controller;
    [SerializeField] private Animator animator;

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

        if (Input.GetMouseButtonDown(0))
        {
            Attack();
        }

        if (Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }


    void Attack()
    {
        animator.SetTrigger("Attack");
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
            animator.SetBool("Running", true);
            //transform.rotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), rotationSpeed);
        }
        else
        {
            animator.SetBool("Running", false);
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

        //bool isJumping = (gravity > 0 || gravity < -0.2f) && !controller.isGrounded;
        //animator.SetBool("Jump", isJumping);
        if (gravity > 0)
        {
            animator.SetInteger("Gravity", 1);
        }
        else if (gravity < -0.3f)
        {
            animator.SetInteger("Gravity", -1);
        }
        else
        {
            animator.SetInteger("Gravity", 0);
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
