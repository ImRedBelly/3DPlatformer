using UnityEngine;

public class Teleport : MonoBehaviour
{
    [SerializeField] private GameObject endPoint;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            PlayerMovement.instance.Teleportation();
            PlayerMovement.instance.transform.position = endPoint.transform.position;
        }
    }
}
