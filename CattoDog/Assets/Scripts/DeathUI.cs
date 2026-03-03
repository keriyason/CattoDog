using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathUI : MonoBehaviour
{
    public static DeathUI Instance;

    [Header("UI")]
    public GameObject deathPanel; // calls to a ui panel

    [Header("Scene Names")]
    public string gameplaySceneName = "Scene1"; //gameplay button
    public string mainMenuSceneName = "MainMenu"; // main menu button

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        deathPanel.SetActive(false); //turn the panel inactive is not visible
    }

    public void ShowDeathScreen()
    {
        deathPanel.SetActive(true); //when u die the panel becomes active and visible

        
        Cursor.lockState = CursorLockMode.None; //unlocks your cursor
        Cursor.visible = true;

    }

    public void RestartGame()
    {
        Time.timeScale = 1f; //pauses game
        SceneManager.LoadScene(gameplaySceneName); //loads game again
    }

    public void ReturnToMenu()
    {
        Time.timeScale = 1f; //pauses game
        SceneManager.LoadScene(mainMenuSceneName); //loads main menu screen
    }

    public void QuitGame()
    {
        Application.Quit(); //quit game
        Debug.Log("Quit Game"); 
    }
}
