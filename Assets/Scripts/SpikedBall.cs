using DG.Tweening;
using UnityEngine;

public class SpikedBall : MonoBehaviour
{
    private void Start()
    {
        DoMove();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.GetComponent<PlayerMovement>().Restart();
        }
    }
    private void DoMove()
    {
        Sequence moveSequence = DOTween.Sequence();

        moveSequence.Append(transform.DOMoveZ(-15, 1).SetEase(Ease.Linear));
        moveSequence.Join(transform.DORotate(new Vector3(0, 180, 0), 1).SetEase(Ease.Linear));

        moveSequence.Append(transform.DOMoveZ(10, 1).SetEase(Ease.Linear));
        moveSequence.Join(transform.DORotate(new Vector3(0, 359, 0), 1).SetEase(Ease.Linear));

        moveSequence.SetLoops(-1);
    }
}
