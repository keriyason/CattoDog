using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CollectibleManager : MonoBehaviour
{
    public static CollectibleManager Instance { get; private set; }

    public Vector3 CurrentCheckpoint { get; private set; }

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

    private void OnEnable()
    {
        CollectibleEventSystem.OnCheckpointReached += UpdateCheckpoint;
    }

    private void OnDisable()
    {
        CollectibleEventSystem.OnCheckpointReached -= UpdateCheckpoint;
    }

    private void UpdateCheckpoint(Vector3 checkpointPos)
    {
        CurrentCheckpoint = checkpointPos;
        Debug.Log("Checkpoint updated to: " + checkpointPos);
    }
}





