using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 1;
    public enum CollectibleType
    {
        Coin,
        Gem
    }

    [SerializeField] CollectibleType type;
    [SerializeField] int amount = 1;

    private void Update()
    {
        transform.Rotate(0, rotateSpeed, 0, Space.World);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        { 
           
          
            Destroy(gameObject);
        }
    }
}
