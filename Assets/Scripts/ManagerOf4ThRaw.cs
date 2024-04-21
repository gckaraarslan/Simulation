using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Random = UnityEngine.Random;

public class ManagerOf4ThRaw : MonoBehaviour
{ 
    public TextMeshProUGUI[] valueTexts = new TextMeshProUGUI[6];

    public float[] initialValues = new float[6];

    public float[] randomValues = new float[6];

    float timer;

    void Update()
    {
        InitialValuesRandomChange();
    }

    void OnEnable()
    {
        InputManager.AKeyGotPressed += AKeyGotPressed;
    }

    void OnDisable()
    {
        InputManager.AKeyGotPressed -= AKeyGotPressed;
    }

    void AKeyGotPressed()
    {
        StartCoroutine(FeaturesWindowAnimation(valueTexts));
    }

    void InitialValuesRandomChange()
    {
        timer += Time.deltaTime;
        if (timer >= 1.5f)
        {
            for (int i = 0; i < initialValues.Length; i++)
            {
                randomValues[i] = Random.Range(initialValues[i] * 0.9f,
                    initialValues[i] * 1.1f);

                valueTexts[i].text = randomValues[i].ToString();
                timer = 0f;
            }
        }
    }


    IEnumerator FeaturesWindowAnimation(TextMeshProUGUI[] arrayList) //dotween ile yapılacak
    {
        foreach (var texts in arrayList)
        {
            texts.fontSize *= 1.1f;
            texts.color = Color.green;
        }


        yield return new WaitForSeconds(2f);


        foreach (var texts in arrayList)
        {
            texts.fontSize *= 10 / 11f; //tekrar eski değere eşitlemek için her birini
            texts.color = Color.black;
        }
    }
}