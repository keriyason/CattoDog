using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillPlayer : MonoBehaviour {
	[SerializeField]Transform spawnPoint;


	void OnCollisionEnter(Collision other)
	{
		if(other.transform.CompareTag("Player"))
			other.transform.position = spawnPoint.position;
	}
}
