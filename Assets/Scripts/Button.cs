using UnityEngine;
using DG.Tweening;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;

public class Button : MonoBehaviour
{
    public UnityEvent OnPressed;
    public UnityEvent OnUnPressed;
   
    private void OnTriggerEnter(Collider other)
    {
        OnPressed.Invoke();
    }

    private void OnTriggerExit(Collider other)
    {
        OnUnPressed.Invoke();
    }

}
