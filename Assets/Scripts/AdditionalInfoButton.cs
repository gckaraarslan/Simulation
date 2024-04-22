using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class AdditionalInfoButton : MonoBehaviour
{
    private Button additionalInfoButton;
    void Start()
    {
        additionalInfoButton = gameObject.GetComponent<Button>();
        additionalInfoButton.onClick.AddListener(AdditionalInfoButtonInteraction);
    }
    
    public void AdditionalInfoButtonInteraction()
    {
        Application.OpenURL("www.google.com");
    }
}
