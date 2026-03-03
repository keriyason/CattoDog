using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPopUp : MonoBehaviour
{
    [Header("UI Elements")]
    public GameObject popupPanel;      // panel pop up
    public TextMeshProUGUI popupText;  // test for panel pop up
    public Button closeButton;         // click button to close
    private void Awake()
    {
        popupPanel.SetActive(false); //sets panel unactive till pickup

        closeButton.onClick.AddListener(ClosePopup); // listener for close button
    }

    public void ShowPopup(string message)
    {
        popupText.text = message; // texts appears when pickup
        popupPanel.SetActive(true); // panel popup

        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;

    }

    public void ClosePopup()
    {
        popupPanel.SetActive(false); //closes popup on button

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
}