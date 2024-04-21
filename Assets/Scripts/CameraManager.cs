using System.Collections;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    
    Camera mainCamera;
    
    [Header("Attributes")] 
    [SerializeField] float zoomDuration = 2f;
    [SerializeField] float targetFOV = 30f; 

    float originalFOV;
    bool isZoomed ;
   
    void OnEnable()
    {
        InputManager.ZoomIn += OnZoomIn;
        UIDataModel.ZoomOut += OnZoomOut;
    }

    private void OnDisable()
    {
        InputManager.ZoomIn -= OnZoomIn;
        UIDataModel.ZoomOut -= OnZoomOut;
    }

    
    void Start()
    {
        mainCamera = gameObject.GetComponent<Camera>();
        isZoomed = false;
        originalFOV = mainCamera.fieldOfView;
    }
    private void OnZoomIn()
    {
        if (!isZoomed)
        {
            StartCoroutine(ZoomIn()); 
            isZoomed = true;
        }
        
       
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

    void OnZoomOut()
    {
        if (isZoomed)
        {
            StartCoroutine(ZoomOut());
            isZoomed = false; 
        }
      
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
}
