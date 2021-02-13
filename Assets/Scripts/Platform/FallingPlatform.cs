using UnityEngine;
using System.Collections;

public class FallingPlatform : MonoBehaviour
{
    public GameObject platform;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            StartCoroutine(Falling());
        }
    }
   
    IEnumerator Falling()
    {
        yield return new WaitForSeconds(2);
        platform.SetActive(false);
        yield return new WaitForSeconds(2);
        platform.SetActive(true);
    }
}
