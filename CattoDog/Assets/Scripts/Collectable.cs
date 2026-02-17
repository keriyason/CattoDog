using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    public int value = 1;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
            CollectibleManager.Instance.Add(value);
            Destroy(gameObject);
        }
    }
}
