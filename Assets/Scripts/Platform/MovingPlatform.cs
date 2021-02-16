using DG.Tweening;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField] private float startPositionPlatform;
    [SerializeField] private float endPositionPlatform;

    private float startPositionDoor;
    private float endPositionDoor;

    public float step;

    private void Start()
    {
        //startPositionPlatform = transform.position.x;
        //endPositionPlatform = startPositionPlatform + step;

        startPositionDoor = transform.position.y;
        endPositionDoor = startPositionDoor + step;
    }
    public void Flying()
    {
        transform.DOLocalMoveX(endPositionPlatform, 3).SetLoops(-1, LoopType.Yoyo).SetUpdate(UpdateType.Fixed);
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
