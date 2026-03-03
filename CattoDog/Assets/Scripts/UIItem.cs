using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIItem : MonoBehaviour
{
    public string itemMessage = "You picked up a special item!"; // pickup item

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            UIPopUp ui = FindObjectOfType<UIPopUp>(); //calls to UIPopUp
            if (ui != null)
            {
                ui.ShowPopup(itemMessage);
            }

            Destroy(gameObject);
        }
    }
}
