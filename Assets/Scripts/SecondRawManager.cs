using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SecondRawManager : MonoBehaviour
{
   
    public TextMeshProUGUI[] secondRawValuesTexts = new TextMeshProUGUI[2];
    public int[] secondRawValues = new int[2];

    void OnEnable()
    {
        InputManager.XKeyGotPressed += XKeyGotPressed;
    }

    private void OnDisable()
    {
        InputManager.XKeyGotPressed -= XKeyGotPressed;
    }

    void XKeyGotPressed()
    {
        SecondRawValuesIncrement();
    }


    void SecondRawValuesIncrement()
    {
        for (int i = 0; i < secondRawValues.Length; i++)
        {
            secondRawValues[i]++;
            secondRawValuesTexts[i].text = secondRawValues[i].ToString();
        }
    }
}