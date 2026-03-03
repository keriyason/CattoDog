using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingObject2 : MonoBehaviour
{
    public int damage = 1;
    public float destroyDelay = 2f; 
    private bool hitGround = false;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            PlayerHealth.Instance.TakeDamage(damage);
        }

        if (!hitGround && IsGround(collision))
        {
            hitGround = true;
            StartCoroutine(DestroyAfterDelay());
        }
    }

    private void Update()
    {
        if (!hitGround)
        {
            Ray ray = new Ray(transform.position, Vector3.down);
            if (Physics.Raycast(ray, 0.1f))
            {
                hitGround = true;
                StartCoroutine(DestroyAfterDelay());
            }
        }
    }

    private bool IsGround(Collision collision)
    {
        return collision.collider.CompareTag("Ground");
    }

    IEnumerator DestroyAfterDelay()
    {
        yield return new WaitForSeconds(destroyDelay);
        Destroy(gameObject);
    }
}