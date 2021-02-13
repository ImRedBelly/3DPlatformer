using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    private float startX;
    private float endX;
    private void Start()
    {
        startX = transform.position.x;
        endX = startX + 5;
    }
    public void Flying()
    {
        Sequence moveSequence = DOTween.Sequence();

        moveSequence.Append(transform.DOMoveX(endX, 1).SetEase(Ease.Linear));

        moveSequence.Append(transform.DOMoveX(startX, 1).SetEase(Ease.Linear));


        moveSequence.SetLoops(-1);
    }
}
