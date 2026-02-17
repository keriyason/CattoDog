using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectibleManager : MonoBehaviour
{
   public static CollectibleManager Instance { get; private set; }
    public int totalCollected;

    private void Awake()
    {
        if (Instance != null && Instance !=this)
        {
            Destroy(gameObject);
            return;

        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
        DontDestroyOnLoad(gameObject);

    }
    public void Add(int amount)
    {
        totalCollected += amount;
        Debug.Log("Collected" + totalCollected);
    }
}
