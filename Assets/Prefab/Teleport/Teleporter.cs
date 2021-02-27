using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleporter : MonoBehaviour
{
    public Transform Other;

    private void OnTriggerEnter(Collider other)
    {
        StartCoroutine(OffTrigger());
        PlayerMovement.instance.Teleportation();
        Teleport(other.transform);
    }

    private void Teleport(Transform obj)
    {
        Vector3 position = new Vector3(Other.position.x, obj.position.y, Other.position.z);
        obj.position = position;  


        Quaternion difference = Other.transform.rotation * Quaternion.Inverse(transform.rotation * Quaternion.Euler(0, 0, 180));
        obj.rotation = difference * obj.rotation;
    }
    IEnumerator OffTrigger()
    {
        Other.GetComponent<BoxCollider>().enabled = false;
        yield return new WaitForSeconds(1);
        Other.GetComponent<BoxCollider>().enabled = true;
    }
}