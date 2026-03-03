using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public string nextSceneName;
    [SerializeField]
    private string
    mainMenuSceneName = "MainMenu";
    [SerializeField]
    private string
    resetSceneName = "ResetScene";
    [SerializeField]
    private string
    gameplaySceneName = "Scene1";

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    public void LoadGame()
    {
        SceneManager.LoadScene(resetSceneName);
        nextSceneName = gameplaySceneName;
    }
    public void ReturnToMenu()
    {
        SceneManager.LoadScene(resetSceneName);
        nextSceneName = mainMenuSceneName;
    }
}


