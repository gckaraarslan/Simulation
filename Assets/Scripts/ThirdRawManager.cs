using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ThirdRawManager : MonoBehaviour
{
   [Header("OEE")]
    public TextMeshProUGUI oEEText;
    public Image oEEFillAmountBar;
    public int oEEValue = 25;
     float timer;
     
     [Header("OrderQuantity")] 
     public TextMeshProUGUI orderQuantityText;
     public int orderQuantityValue = 250;
     public int maxOrderQuantityValue = 800;
     public Image orderQuantityBar;

     void OnEnable()
     {
         InputManager.XKeyGotPressed += XKeyGotPressed;
     }

     private void OnDisable()
     {
         InputManager.XKeyGotPressed -= XKeyGotPressed;
     }
    void Update()
    {
        OEEValueRandomlyChange();
       
    }
    void OEEValueRandomlyChange()
    {
        int minValOfOEE = 75;
        int maxValOfOEE = 85;

        timer += Time.deltaTime;
        if (timer >= 2f)  //case'de 60(dakika) isteniyor ama test etmek için 2 sn yaptım
        {
            oEEValue = Random.Range(minValOfOEE, maxValOfOEE);
            timer = 0f;
        }

        oEEText.text = "%" + oEEValue;
        oEEFillAmountBar.fillAmount = (float)oEEValue / 100;
    }
    void XKeyGotPressed()
    {
        OrderQuantityValueIncrement();
    }
    void OrderQuantityValueIncrement()
    {
        orderQuantityValue += 50;
        orderQuantityBar.fillAmount = orderQuantityValue / (float)maxOrderQuantityValue;
        orderQuantityText.text = orderQuantityValue + "/" + maxOrderQuantityValue;
        orderQuantityValue = Mathf.Min(orderQuantityValue, maxOrderQuantityValue - 50);
    }
}
