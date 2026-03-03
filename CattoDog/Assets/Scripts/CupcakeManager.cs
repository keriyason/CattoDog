using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CupcakeManager : MonoBehaviour
{
    public static CupcakeManager Instance;

    public int cupcakesNeeded = 1; ///how many cupcakes are needed to collect
    private int currentCupcakes = 0; // inital cupcakes collected and track how many u currently have

    public delegate void CupcakeCountChanged(int current, int needed);
    public static event CupcakeCountChanged OnCupcakeCountChanged;


    private void Awake()
    {
        Instance = this;
    }

    private void OnEnable()
    {
        CupcakeEvent.OnCupcakeCollected += AddCupcake; // calls to event 
    }

    private void OnDisable()
    {
        CupcakeEvent.OnCupcakeCollected -= AddCupcake;
    }

    void AddCupcake()
    {
        currentCupcakes++;

        OnCupcakeCountChanged?.Invoke(currentCupcakes, cupcakesNeeded);

        if (currentCupcakes >= cupcakesNeeded)
        {
            WinGame();
        }
    }

    void WinGame()
    {
        Debug.Log("YOU WIN!");
        Time.timeScale = 1f;
        SceneManager.LoadScene("WinScreen");

    }
}
