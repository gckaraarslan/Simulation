using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SceneManager : MonoBehaviour
{
    [Header("References")] 
    [SerializeField] Camera mainCamera;
    [SerializeField] private GameObject featuresWindow;
   [SerializeField] private GameObject zoomOutButton;
   [SerializeField] private GameObject nameCard;
   [SerializeField] private GameObject informativeText;
   

    [Header("Attributes")] 
    [SerializeField] float zoomDuration = 2f;

    [SerializeField] float targetFOV = 30f; //targetField of View

    float originalFOV;
    bool isZoomed ;

    private void Start()
    {
        isZoomed = false;
        originalFOV = mainCamera.fieldOfView;
        zoomOutButton.SetActive(false);
        featuresWindow.SetActive(false);
    }

    private void OnMouseDown()
    {
        if (!isZoomed)
        {
            StartCoroutine(ZoomIn());
            isZoomed = true;
            ZoomInUIChanges();
           
        }
    }

    void ZoomInUIChanges()
    {
        zoomOutButton.SetActive(true);
        featuresWindow.SetActive(true);
        nameCard.SetActive(false);
        informativeText.SetActive(false);  
    }

    

    private IEnumerator ZoomIn()
    {
        float currentTime = 0f;

        while (currentTime < zoomDuration)
        {
            currentTime += Time.deltaTime;
            float t = currentTime / zoomDuration;
            mainCamera.fieldOfView = Mathf.Lerp(originalFOV, targetFOV, t);
            yield return null;
        }
    }
    
    public void ZoomOutButtonInteraction()
    {
        StartCoroutine(ZoomOut());
        ZoomOutUIChanges();
        isZoomed = false;
    }

    private IEnumerator ZoomOut() 
    {
     
        float currentTime = 0f;

        while (currentTime < zoomDuration)
        {
            currentTime += Time.deltaTime;
            float t = currentTime / zoomDuration;
            mainCamera.fieldOfView = Mathf.Lerp(targetFOV, originalFOV, t);
            yield return null;
        }
    }
    void ZoomOutUIChanges()
    {
        zoomOutButton.SetActive(false);
        featuresWindow.SetActive(false);
        nameCard.SetActive(true);
        informativeText.SetActive(true);
    }
}