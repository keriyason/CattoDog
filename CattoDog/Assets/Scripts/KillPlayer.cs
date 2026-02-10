using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {
	[SerializeField]Transform spawnPoint; // where the player will respawn


	void OnCollisionEnter(Collision other) //if the player collides with GO reset to spawn point
	{
		if(other.transform.CompareTag("Player"))
			other.transform.position = spawnPoint.position;
	}
}
