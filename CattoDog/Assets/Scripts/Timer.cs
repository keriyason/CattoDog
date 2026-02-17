using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour

{
    public float timeRemaining = 60f;
    public bool timerIsRunning = false;
    public TMP_Text timerText;
    public AudioSource bellSound;

    void Start()
    {
        timerIsRunning = false;
    }

    void OnTriggerEnter(Collider other)
    {

        if (other.CompareTag("Player"))
        {
            if (!timerIsRunning)
            {
                timerIsRunning = true;
                Debug.Log("Timer started!");
            }
        }
    }
    void Update()
    {
        if (timerIsRunning)
        {
            if (timeRemaining > 0)
            {
                timeRemaining -= Time.deltaTime;
                DisplayTime(timeRemaining);
            }
            else
            {
                timeRemaining = 0;
                timerIsRunning = false;
                DisplayTime(timeRemaining);

                Debug.Log("Game Over");
                StartCoroutine(TriggerFailSequence());
            }
        }
    }

    IEnumerator TriggerFailSequence()
    {
        if (bellSound != null)
        {
            bellSound.Play();
        }

        yield return new WaitForSeconds(5f); // 5 Second Delay

        SceneManager.LoadScene("FailScene");
    }

    void DisplayTime(float timeToDisplay)
    {
        timeToDisplay += 1;

        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }

}
