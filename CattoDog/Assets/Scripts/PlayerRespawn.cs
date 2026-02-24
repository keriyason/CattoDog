using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRespawn : MonoBehaviour
{
    private Rigidbody rb; //ref players rigidbody

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    private void Start()
    {
        Respawn(); //player spawns at last saved checkpoint
    }

    public void Respawn()
    {
        if (CheckpointManager.Instance == null) return; // do nothing is checkpoitn system is activated

        Vector3 checkpoint = CheckpointManager.Instance.GetCheckpoint(); //tracks last checkpoint save

        if (checkpoint == Vector3.zero) return; //if no checkpoint has been set do nothing

        rb.velocity = Vector3.zero; //stop player movement from continously falling
        rb.angularVelocity = Vector3.zero;

        rb.position = checkpoint; //teleports player for last checkpoint
    }
}