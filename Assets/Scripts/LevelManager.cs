using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelManager : MonoBehaviour
{
    public GameObject teleport;
    public int coinLenght;
    public static LevelManager instance { get; private set; }
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }
        instance = this;
    }

    public void CoinCreated()
    {
        coinLenght++;
    }
    public void CoinDestroyed()
    {
        coinLenght--;

        if (coinLenght <= 0)
        {
            teleport.SetActive(true);
        }
    }


}
