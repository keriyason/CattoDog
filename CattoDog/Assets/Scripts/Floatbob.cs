using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Floatbob : MonoBehaviour
{
    public Vector3 bobSpeed = new Vector3(0f, 50f, 0f); // bob

    private void Update() => transform.position = bobSpeed;
}
