
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class FallingObject : MonoBehaviour
{

    [SerializeField] public GameObject highlighterPrefab;
    [SerializeField] public Transform spawnPoint;
    [SerializeField] private float spawnInterval;


    private int spawnCount;

    private void Start()
    {
        spawnCount = 0;
        InvokeRepeating("SpawnHighlighter", spawnInterval, spawnInterval);
    }

    private void Update()
    {
        if (spawnCount == 1)
        {
            CancelInvoke();
        }
    }

    void SpawnHighlighter()
    {
        if (spawnPoint != null)
        {
            spawnCount++;

            Instantiate(highlighterPrefab, spawnPoint.position, Quaternion.identity);
        }
        else
        {
            Debug.Log("bleh");
        }

    }
}