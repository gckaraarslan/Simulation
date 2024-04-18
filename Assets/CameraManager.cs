using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
   
    void Start()
    {
        EventManager.onZoomIn += ZoomIn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void ZoomIn()
    {
       //fonsiyon
    }
}
