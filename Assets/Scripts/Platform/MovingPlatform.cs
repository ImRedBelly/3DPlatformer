using DG.Tweening;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private float startPositionPlatform;
    private float endPositionPlatform;

    private float startPositionDoor;
    private float endPositionDoor;

    public float step;

    private void Start()
    {
        startPositionPlatform = transform.position.x;
        endPositionPlatform = startPositionPlatform + step;

        startPositionDoor = transform.position.y;
        endPositionDoor = startPositionDoor + step;
    }
    public void Flying()
    {
        Sequence moveSequence = DOTween.Sequence();
        moveSequence.Append(transform.DOMoveX(endPositionPlatform, 2).SetEase(Ease.Linear));

        moveSequence.Append(transform.DOMoveX(startPositionPlatform, 2).SetEase(Ease.Linear));

        moveSequence.SetLoops(-1);
    }

    public void Open()
    {
        transform.DOMoveY(endPositionDoor, 3).SetEase(Ease.Linear);
    }
    public void Closed()
    {
        transform.DOMoveY(startPositionDoor, 3).SetEase(Ease.Linear);
    }


    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.SetParent(gameObject.transform, false);
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
