using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuControl : MonoBehaviour
{
    public void StartGame()
    {
        GameManager.Instance.LoadGame();
    }
    public void ExitGame()
    {
        Debug.Log("exit");
        Application.Quit();
    }

}
