using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointManager : MonoBehaviour
{
    public static CheckpointManager Instance;
    [Header ("Inital Spawn Point")]
    public Transform initialSpawnPoint; // where the player first spawns

    private Vector3 currentCheckpoint; //tracks where the location of the current checkpoint is
    private int starsCollected; //how many stars have been collected
    private bool hasCheckpointSaved = false; 

    private void Awake()
    {
        Instance = this;


        if (PlayerPrefs.HasKey("StarsCollected")) 
        {
            starsCollected = PlayerPrefs.GetInt("StarsCollected");

            if (starsCollected > 0)
            {

                Instance = this;

                currentCheckpoint = initialSpawnPoint != null ? initialSpawnPoint.position : Vector3.zero; //goes to inital spawn if no stars have been collected
                starsCollected = 0;
                hasCheckpointSaved = true;
            }
        }
    }



    private void OnEnable() //calls to the event system and updates when a checkpoint star is collected
    {
        StarEvent.OnStarCollected += SaveCheckpoint;
    }

    private void OnDisable() //stops listening when disabled
    {
        StarEvent.OnStarCollected -= SaveCheckpoint;
    }

    private void SaveCheckpoint(int starID, Vector3 position)
    {
        starsCollected++; //adds how many stars collected
        currentCheckpoint = position; //tracks the current checkpoint location
        hasCheckpointSaved = true; // marks that you now have collected stars

        //PlayerPrefs.SetInt("StarsCollected", starsCollected);
        //PlayerPrefs.SetFloat("CheckpointX", position.x);
       // PlayerPrefs.SetFloat("CheckpointY", position.y);
        //PlayerPrefs.SetFloat("CheckpointZ", position.z);
        //PlayerPrefs.Save();
    }

    public Vector3 GetCheckpoint()
    {
        return currentCheckpoint; //returns player to the last checkpoint
    }

    public int GetStarCount()
    {
        return starsCollected; // tracks how many stars have been collected
    }
}
