using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    float timer;
    private float timerOfFourthRaw;
    public List<TextMeshProUGUI> animationTexts;

    #region FourthRawDatasVariables

    public TextMeshProUGUI stoveTempValueText;
    private int initialStoveTempValue = 500; //°C

    public TextMeshProUGUI upperMoldTempValueText;
    private int initialUpperMoldTempValue = 25; //°C

    public TextMeshProUGUI accelerationValueText;
    private double initialAccelerationValue = 0.15; //mm/s²

    public TextMeshProUGUI stoveWeightValueText;
    private int initialStoveWeightValue = 800; //kg

    public TextMeshProUGUI lowerMoldTempValueText;
    private int initialLowerMoldTempValue = 15; //°C

    public TextMeshProUGUI pressureValueText;
    private double initialPressureValue = 0.250; //bar

    #endregion

    #region OrderCode&MaterialCodeVariables

    public TextMeshProUGUI orderCodeValueText;
    private int orderCodeValue = 2051920;
    public TextMeshProUGUI materialCodeValueText;
    int materialCodeValue = 2051920;

    #endregion

    #region OrderQuantityVariables

    public TextMeshProUGUI orderQuantityText;
    private int orderQuantityValue = 250;
    private int maxOrderQuantityValue = 800;
    public Image orderQuantityBar;

    #endregion

    #region OEE Variables

    public TextMeshProUGUI oEEText;
    public Image oEEFillAmountBar;
    int oEEValue = 25;

    #endregion

    void Start()
    {
        #region MaterialCode & OrderCode

        materialCodeValueText.text = "O-" + materialCodeValue;
        orderCodeValueText.text = "O-" + orderCodeValue;

        #endregion

        #region OrderQuantity

        orderQuantityText.text = orderQuantityValue + "/" + maxOrderQuantityValue;
        orderQuantityBar.fillAmount = orderQuantityValue / (float)maxOrderQuantityValue;

        #endregion

        #region OEE

        oEEText.text = "%" + oEEValue;
        oEEFillAmountBar.fillAmount = oEEValue / 100f;

        #endregion
    }


    void Update()
    {
        OEEVALUECHANGE();
        RandomlyChangesOfDatasInTheFourthRaw();

        if (Input.GetKeyDown(KeyCode.X))
        {
            OrderCodeValueIncrement();

            MaterialCodeValueIncrement();
            OrderQuantityValueIncrement();
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            StartCoroutine(FeaturesWindowAnimation());
        }
    }

    void OrderCodeValueIncrement()
    {
        orderCodeValue++;
        orderCodeValueText.text = "O-" + orderCodeValue;
    }

    void MaterialCodeValueIncrement()
    {
        materialCodeValue++;
        materialCodeValueText.text = "O-" + materialCodeValue;
    }

    void OrderQuantityValueIncrement()
    {
        orderQuantityValue += 50;
        orderQuantityBar.fillAmount = orderQuantityValue / (float)maxOrderQuantityValue;
        orderQuantityText.text = orderQuantityValue + "/" + maxOrderQuantityValue;
        orderQuantityValue = Mathf.Min(orderQuantityValue, maxOrderQuantityValue);
    }

    void OEEVALUECHANGE()
    {
        int minValOfOEE = 75;
        int maxValOfOEE = 85;

        timer += Time.deltaTime;
        if (timer >= 2f) //case'de 60(dakika) isteniyor ama test etmek için 2 sn yaptım
        {
            oEEValue = Random.Range(minValOfOEE, maxValOfOEE);
            timer = 0f;
        }

        oEEText.text = "%" + oEEValue;
        oEEFillAmountBar.fillAmount = (float)oEEValue / 100;
    }

    void RandomlyChangesOfDatasInTheFourthRaw()
    {
        #region stovetemp

        float minValOfStoveTempValue = initialStoveTempValue * 1.1f;
        float maxValOfStoveTempValue = initialStoveTempValue * 0.9f;
        float randomValueOfStoveTempValue;

        #endregion

        #region uppermoldtemp

        float minValOfUpperMoldTempValue = initialUpperMoldTempValue * 0.9f;
        float maxValOfUpperMoldTempValue = initialUpperMoldTempValue * 1.1f;
        float randomValueOfUpperMoldTempValue;

        #endregion

        #region acceleration

        float minValOfAccelerationValue = (float)initialAccelerationValue * 0.9f;
        float maxValOfAccelerationValue = (float)initialAccelerationValue * 1.1f;
        float randomValOfAccelerationValue;

        #endregion

        #region stoveweight

        float minValOfStoveWeightValue = initialStoveWeightValue * 0.9f;
        float maxValOfStoveWeightValue = initialStoveWeightValue * 1.1f;
        float randomValOfStoveWeightValue;

        #endregion

        #region lowermoldtemp

        float minValOfLowerMoldTempValue = initialLowerMoldTempValue * 0.9f;
        float maxValOfLowerMoldTempValue = initialLowerMoldTempValue * 1.1f;
        float randomValOfLowerMoldTempValue;

        #endregion

        #region pressure

        float minValOfPressureValue = (float)initialPressureValue * 0.9f;
        float maxValOfPressureValue = (float)initialPressureValue * 1.1f;
        float randomValOfPressureValue;

        #endregion

        timerOfFourthRaw += Time.deltaTime;
        if (timerOfFourthRaw >= 1.5f)
        {
            #region CalculationsOfRandomValues

            randomValueOfStoveTempValue = Random.Range(minValOfStoveTempValue, maxValOfStoveTempValue);
            randomValueOfUpperMoldTempValue = Random.Range(minValOfUpperMoldTempValue, maxValOfUpperMoldTempValue);
            randomValOfAccelerationValue = Random.Range(minValOfAccelerationValue, maxValOfAccelerationValue);
            randomValOfStoveWeightValue = Random.Range(minValOfStoveWeightValue, maxValOfStoveWeightValue);
            randomValOfLowerMoldTempValue = Random.Range(minValOfLowerMoldTempValue, maxValOfLowerMoldTempValue);
            randomValOfPressureValue = Random.Range(minValOfPressureValue, maxValOfPressureValue);

            #endregion

            timerOfFourthRaw = 0f;

            #region UITextDatas

            stoveTempValueText.text = randomValueOfStoveTempValue + "°C";
            upperMoldTempValueText.text = randomValueOfUpperMoldTempValue + "°C";
            accelerationValueText.text = randomValOfAccelerationValue + "mm/s²";
            stoveWeightValueText.text = randomValOfStoveWeightValue + "kg";
            lowerMoldTempValueText.text = randomValOfLowerMoldTempValue + "°C";
            pressureValueText.text = randomValOfPressureValue + " bar";

            #endregion
        }
    }

    public void AdditionalInfoButtonInteraction()
    {
        Application.OpenURL("www.google.com");
    }

    IEnumerator FeaturesWindowAnimation()
    {
        foreach (var texts in animationTexts)
        {
            texts.fontSize *= 1.1f;
            texts.color = Color.green;
        }


        yield return new WaitForSeconds(2f);


        foreach (var texts in animationTexts)
        {
            texts.fontSize *= 10 / 11f; //tekrar eski değere eşitlemek için her birini
            texts.color = Color.white;
        }
    }
}