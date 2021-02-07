using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Button : MonoBehaviour
{
    public GameObject door;

    bool isOpen = false;

    private void Update()
    {
        if (isOpen)
        {
            door.transform.Translate(new Vector3(0, 1, 0) * Time.deltaTime);
            if (door.transform.position.y > 27)
            {
                door.transform.position = new Vector3(door.transform.position.x, 27, door.transform.position.z);
            }
        }
        else
        {
            door.transform.Translate(new Vector3(0, -1, 0) * Time.deltaTime);
            if (door.transform.position.y < 20)
            {
                door.transform.position = new Vector3(door.transform.position.x, 20, door.transform.position.z);
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOpen = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            isOpen = false;
        }
    }
}
