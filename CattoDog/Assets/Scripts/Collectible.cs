using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Collectible : MonoBehaviour
{
    [SerializeField] float rotateSpeed = 90f;
    [SerializeField] Transform spawnPoint;

    void Update()
    {
        transform.Rotate(0f, rotateSpeed * Time.deltaTime, 0f, Space.World);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            CollectibleEventSystem.RaiseCheckpointReached(spawnPoint.position);
            Debug.Log("Checkpoint reached!");
            Destroy(gameObject);
        }
    }
}





