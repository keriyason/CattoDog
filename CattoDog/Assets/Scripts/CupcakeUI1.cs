using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CupcakeUI1 : MonoBehaviour
{
    public TextMeshProUGUI cupcakeText; // attaches UI text for tracker

    private void OnEnable()
    {
        CupcakeManager.OnCupcakeCountChanged += UpdateUI; 
    }

    private void OnDisable()
    {
        CupcakeManager.OnCupcakeCountChanged -= UpdateUI;
    }

    void UpdateUI(int current, int needed)
    {
        cupcakeText.text = "Cupcakes: " + current + " / " + needed;
    }
}
