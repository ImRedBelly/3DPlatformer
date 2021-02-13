using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private GameObject endPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().teleportPoint = endPoint.transform.position;
            other.GetComponent<PlayerMovement>().Teleportation();
        }
    }
}
