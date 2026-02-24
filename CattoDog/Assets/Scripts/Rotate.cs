using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    [Header("Rotation Settings")]
    public Vector3 rotationSpeed = new Vector3(0f, 50f, 0f); // rotation

    private void Update()
    {
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}
