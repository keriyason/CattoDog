using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarCollectible : MonoBehaviour
{
    public int starID; //tracks different stars 

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) //reachs to Player
        {
            StarEvent.OnStarCollected?.Invoke(starID, transform.position); //tells the event system that a star was collected and sends the stars information and postion for checkpoint respawn
            Destroy(gameObject); // object disappears yay
        }
    }
}