using DG.Tweening;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float startPositionPlatform;
    [SerializeField] private float endPositionPlatform;
    [SerializeField] Vector3 endRotateDoor;



    public void Flying()
    {
        transform.DOMoveX(endPositionPlatform, 10).SetLoops(-1, LoopType.Yoyo).SetUpdate(UpdateType.Fixed).SetEase(Ease.Linear);
    }

    public void OpenDoor()
    {
        transform.DOLocalRotate(endRotateDoor, 10).SetEase(Ease.Linear);
    }



    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(transform);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(null);
        }
    }

}
