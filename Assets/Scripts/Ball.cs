using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Ball : MonoBehaviour
{
    [SerializeField] private Rigidbody rb;
    private void ResetPosition()
    {
        //TODO random
        transform.position = new Vector3(0, 5, 0);
        rb.velocity = Vector3.zero;
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Target"))
        {
            ResetPosition();
        }
        if (collision.gameObject.CompareTag("Hell"))
        {
            ResetPosition();
        }
    }
}
