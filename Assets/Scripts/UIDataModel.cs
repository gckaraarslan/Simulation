using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


public class UIDataModel : MonoBehaviour
{
    public delegate void OnMouseClicked();

    public static event OnMouseClicked ZoomOut;

    [Header("References")]
    public GameObject featuresWindow;
    public Button zoomOutButton;
    public GameObject nameCard;
    public GameObject informativeText;


    void Start()
    {
        zoomOutButton.gameObject.SetActive(false);
        zoomOutButton.onClick.AddListener(ZoomOutClicked);
        featuresWindow.SetActive(false);
    }

    void ZoomOutClicked()
    {
        ZoomOut?.Invoke();
    }
}