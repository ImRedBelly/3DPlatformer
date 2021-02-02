using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerMovement : MonoBehaviour
{

    [Header("Playre Movement")]

    [SerializeField] private float speed = 10f;
    [SerializeField] private float rotationSpeed = 1f;
    [SerializeField] private float jumpForce = 300f;

    [SerializeField] private Rigidbody rb;


    [Header("Setting pushing")]

    [SerializeField] private GameObject searchCenter;
    [SerializeField] private float searchRadius;
    [SerializeField] private LayerMask searchMask;
    [SerializeField] private float maxPushForce = 5;
    [SerializeField] private float pushHeight = 5f;
    float pushForce;
    float time;

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            rb.AddForce(Vector3.up * jumpForce);
        }

        if (Input.GetMouseButton(0))
        {
            time += Time.deltaTime;

        }

        if (Input.GetMouseButtonUp(0))
        {
            Collider[] balls = Physics.OverlapSphere(searchCenter.transform.position, searchRadius, searchMask);
            foreach (Collider coll in balls)
            {
                Rigidbody ballRb = coll.GetComponent<Rigidbody>();

                Vector3 forceDirection = transform.forward;
                forceDirection.y = pushHeight;
                pushForce = ((1 + Mathf.Sin(time)) / 2) * maxPushForce;
                ballRb.AddForce(forceDirection.normalized * pushForce, ForceMode.Impulse);
            }
        }
    }

    private void FixedUpdate()
    {
        float inputHorizontal = Input.GetAxis("Horizontal");
        float inputVertical = Input.GetAxis("Vertical");

        rb.AddForce(transform.forward * inputVertical * speed);

        transform.RotateAround(transform.position, Vector3.up, inputHorizontal * rotationSpeed);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(searchCenter.transform.position, searchRadius);
    }

}

