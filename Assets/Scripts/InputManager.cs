using System;
using UnityEngine;


public class InputManager : MonoBehaviour
{
    
    public delegate void OnMouseClicked();

    public static event OnMouseClicked ZoomIn;

    public static event Action XKeyGotPressed;
    public static event Action AKeyGotPressed;


    private void OnMouseDown()  //raycasthit'e dönüştürülecek ve script cube'ten çıkarılıp emptyobject (inputmanager) içine alınacak
    {
      
        ZoomIn?.Invoke();
    }

    private void Update()
    {
        
        
        if (Input.GetKeyDown(KeyCode.X))
        {
            XKeyGotPressed?.Invoke();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            AKeyGotPressed?.Invoke();
        }
    }

    
   
}