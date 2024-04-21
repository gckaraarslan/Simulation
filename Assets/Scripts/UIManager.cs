using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;


public class UIManager : MonoBehaviour
{
    private UIDataModel _model;

    void Start()
    {
        _model = GetComponent<UIDataModel>();
    }

    void OnEnable()
    {
        InputManager.ZoomIn += ZoomInUIChanges;
        UIDataModel.ZoomOut += ZoomOutUIChanges;
    }

    private void OnDisable()
    {
        InputManager.ZoomIn -= ZoomInUIChanges;
        UIDataModel.ZoomOut -= ZoomOutUIChanges;
    }

    void ZoomInUIChanges()
    {
        _model.zoomOutButton.gameObject.SetActive(true);
        _model.featuresWindow.SetActive(true);
        _model.nameCard.SetActive(false);
        _model.informativeText.SetActive(false);
    }

    void ZoomOutUIChanges()
    {
        _model.zoomOutButton.gameObject.SetActive(false);
        _model.featuresWindow.SetActive(false);
        _model.nameCard.SetActive(true);
        _model.informativeText.SetActive(true);
    }
}