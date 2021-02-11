using UnityEngine;
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;

public class Spikes : MonoBehaviour
{
    [SerializeField] private float downY;
    [SerializeField] private float upY;
    [SerializeField] private float upTime = 2f;
    [SerializeField] private float downTime = 2f;

    [SerializeField] private float downDelay = 1f;
    [SerializeField] private float upDelay = 1f;
    private void Start()
    {
        Vector3 newPos = transform.position;
        newPos.y = downY;
        transform.position = newPos;

        Sequence moveSequence = DOTween.Sequence();
        
        moveSequence.Append(transform.DOMoveY(upY, upTime));
        moveSequence.AppendInterval(upDelay);

        moveSequence.Append(transform.DOMoveY(downY, downTime).SetDelay(3));
        moveSequence.AppendInterval(downDelay);
        moveSequence.SetLoops(-1);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            HealthPlayer.Instance.DoDamage();
        }
    }
}
