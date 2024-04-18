using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManager : MonoBehaviour
{
    public delegate void OnZoomIn();
    public static event OnZoomIn onZoomIn;
    void Start()
    {
        onZoomIn?.Invoke();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
