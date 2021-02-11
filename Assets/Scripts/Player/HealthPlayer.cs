using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HealthPlayer : MonoBehaviour
{
    public static HealthPlayer Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
    }

  
    public void DoDamage()
    {
        PlayerMovement.instance.Restart();
    }
}
