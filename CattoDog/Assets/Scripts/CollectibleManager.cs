using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static Collectable;

public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager Instance { get; private set; }
    private Dictionary<CollectibleType, int< collectbles;
        new Dictionary<CollectibleType, int>();


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;

        }
        Instance = this;
        DontDestroyOnLoad(gameObject);

    }
    foreach (CollectibleType type in System.Enum.GetValues(typeof(CollectibleType)))
        {
    collectibles[typeof] = 0;
    }

}
