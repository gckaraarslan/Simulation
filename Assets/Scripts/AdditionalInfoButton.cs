using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


public class AdditionalInfoButton : MonoBehaviour
{
    public Button additionalInfoButton;
    void Start()
    {
        additionalInfoButton.onClick.AddListener(AdditionalInfoButtonInteraction);
    }
    
    public void AdditionalInfoButtonInteraction()
    {
        Application.OpenURL("www.google.com");
    }
}
