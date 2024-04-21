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
        InputManager.XKeyGotPressed += XKeyGotPressed;
        InputManager.AKeyGotPressed += AKeyGotPressed;
    }

    private void OnDisable()
    {
        InputManager.ZoomIn -= ZoomInUIChanges;
        UIDataModel.ZoomOut -= ZoomOutUIChanges;
        InputManager.XKeyGotPressed -= XKeyGotPressed;
        InputManager.AKeyGotPressed -= AKeyGotPressed;
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

    void XKeyGotPressed()
    {
        SecondRawValuesIncrement();
        OrderQuantityValueIncrement();
    }

    void AKeyGotPressed()
    {
        StartCoroutine(FeaturesWindowAnimation());
    }

    void Update()
    {
        OEEValueRandomlyChange();
        RandomlyChangesOfDatasInTheFourthRaw();
    }

    void SecondRawValuesIncrement()
    {
        for (int i = 0; i < _model.secondRawValues.Length; i++)
        {
            _model.secondRawValues[i]++;
            _model.secondRawValuesTexts[i].text = _model.secondRawValues[i].ToString();
        }
    }

    void OrderQuantityValueIncrement()
    {
        _model.orderQuantityValue += 50;
        _model.orderQuantityBar.fillAmount = _model.orderQuantityValue / (float)_model.maxOrderQuantityValue;
        _model.orderQuantityText.text = _model.orderQuantityValue + "/" + _model.maxOrderQuantityValue;
        _model.orderQuantityValue = Mathf.Min(_model.orderQuantityValue, _model.maxOrderQuantityValue - 50);
    }

    void OEEValueRandomlyChange()
    {
        int minValOfOEE = 75;
        int maxValOfOEE = 85;

        _model.timer += Time.deltaTime;
        if (_model.timer >= 2f) //case'de 60(dakika) isteniyor ama test etmek için 2 sn yaptım
        {
            _model.oEEValue = Random.Range(minValOfOEE, maxValOfOEE);
            _model.timer = 0f;
        }

        _model.oEEText.text = "%" + _model.oEEValue;
        _model.oEEFillAmountBar.fillAmount = (float)_model.oEEValue / 100;
    }

    void RandomlyChangesOfDatasInTheFourthRaw()
    {
        _model.timerOfFourthRaw += Time.deltaTime;
        if (_model.timerOfFourthRaw >= 1.5f)
        {
            for (int i = 0; i < _model.initialValuesOf4thRaw.Length; i++)
            {
                _model.randomValuesOf4thRaw[i] = Random.Range((float)_model.initialValuesOf4thRaw[i] * 0.9f,
                    (float)_model.initialValuesOf4thRaw[i] * 1.1f);

                _model.textsOfFourthRawValues[i].text = _model.randomValuesOf4thRaw[i].ToString();
                _model.timerOfFourthRaw = 0f;
            }
        }
    }

    public void AdditionalInfoButtonInteraction()
    {
        Application.OpenURL("www.google.com");
    }

    IEnumerator FeaturesWindowAnimation()
    {
        foreach (var texts in _model.textsOfFourthRawValues)
        {
            texts.fontSize *= 1.1f;
            texts.color = Color.green;
        }


        yield return new WaitForSeconds(2f);


        foreach (var texts in _model.textsOfFourthRawValues)
        {
            texts.fontSize *= 10 / 11f; //tekrar eski değere eşitlemek için her birini
            texts.color = Color.black;
        }
    }
}