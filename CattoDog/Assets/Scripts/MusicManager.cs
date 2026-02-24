using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    [SerializeField] private AudioClip gameplayMusic;
    private AudioSource audioSource;

        private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.clip = gameplayMusic;
        audioSource.loop = true;

        audioSource.Play();

    }
}
