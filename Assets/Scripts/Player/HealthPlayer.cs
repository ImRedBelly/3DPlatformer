using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HealthPlayer : MonoBehaviour
{
    public static HealthPlayer Instance { get; private set; }

    public int health = 1;
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
        health--;
        if (health <= 0)
        {
            PlayerMovement.instance.Restart();
        }
    }
}
