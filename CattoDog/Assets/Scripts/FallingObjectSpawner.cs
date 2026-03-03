using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObjectSpawner : MonoBehaviour
{
    [Header("Prefabs To Spawn")]
    public GameObject[] fallingPrefabs; // drag multiple prefabs here

    [Header("Spawn Settings")]
    public float spawnRadius = 10f; // how far the spawn will be
    public float spawnHeight = 20f; // height of spawn
    public float spawnInterval = 2f;// time inbetween eachs spawn

    private void Start()
    {
        InvokeRepeating(nameof(SpawnObject), 1f, spawnInterval);
    }

    void SpawnObject()
    {
        if (fallingPrefabs.Length == 0) return;

        int randomIndex = Random.Range(0, fallingPrefabs.Length); //chooses a random prefab to spawn
        GameObject prefabToSpawn = fallingPrefabs[randomIndex];

        Vector3 randomOffset = new Vector3(
            Random.Range(-spawnRadius, spawnRadius),
            spawnHeight,
            Random.Range(-spawnRadius, spawnRadius)
        );

        Vector3 spawnPos = transform.position + randomOffset;

        Instantiate(prefabToSpawn, spawnPos, Quaternion.identity);
    }
}
