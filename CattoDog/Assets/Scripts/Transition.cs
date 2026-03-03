using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    public string sceneToLoad = "RecordPlayer";

    private void Start()
    {
        Collider col = GetComponent<Collider>();
        if (!col.isTrigger)
            col.isTrigger = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            Time.timeScale = 1f; 
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}