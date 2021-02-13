using UnityEngine;
using DG.Tweening;

public class Coin : MonoBehaviour
{
    private void Start()
    {
        LevelManager.instance.CoinCreated();
        DoMove();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            LevelManager.instance.CoinDestroyed();
            Destroy(gameObject, 0.1f);
        }
    }

    private void DoMove()
    {
        Sequence moveSequence = DOTween.Sequence();

        moveSequence.Append(transform.DOMoveY(4, 1).SetEase(Ease.Linear));
        moveSequence.Join(transform.DORotate(new Vector3(0, 180, 90), 1).SetEase(Ease.Linear));

        moveSequence.Append(transform.DOMoveY(3, 1).SetEase(Ease.Linear));
        moveSequence.Join(transform.DORotate(new Vector3(0, 359, 90), 1).SetEase(Ease.Linear));

        moveSequence.SetLoops(-1);
    }
}
