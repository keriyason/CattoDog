using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupcakeCollectible : MonoBehaviour
{
    public float destroyAfterSeconds = 3f; // destroys object even if not collected
    private bool collected = false; //checks if the object is collceted
    private void Start()
    {
        Invoke(nameof(AutoDestroy), destroyAfterSeconds); //starts the destoy of cupcake
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player") && !collected)
        {
            collected = true;

            CupcakeEvent.OnCupcakeCollected?.Invoke();
            Destroy(gameObject);
        }
    }

    void AutoDestroy()
    {
        if (!collected)
        {
            Destroy(gameObject);
        }
    }
}
