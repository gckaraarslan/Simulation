using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;


public class UIDataModel : MonoBehaviour
{
    public delegate void OnMouseClicked();

    public static event OnMouseClicked ZoomOut;

    [Header("References")] 
    public GameObject featuresWindow;
    public Button zoomOutButton;
    public GameObject nameCard;
    public GameObject informativeText;

    [Header("4th Raw")] 
    public TextMeshProUGUI[] textsOfFourthRawValues = new TextMeshProUGUI[6];
    public double[] initialValuesOf4thRaw = new double[6];
    public float[] randomValuesOf4thRaw = new float[6];
    
    [Header("2nd Raw")] 
    public TextMeshProUGUI[] secondRawValuesTexts = new TextMeshProUGUI[2];
    public int[] secondRawValues = new int[2];

    [Header("OrderQuantity")] 
    public TextMeshProUGUI orderQuantityText;
    public int orderQuantityValue = 250;
    public int maxOrderQuantityValue = 800;
    public Image orderQuantityBar;


    [Header("OEE")]
    public TextMeshProUGUI oEEText;
    public Image oEEFillAmountBar;
    public int oEEValue = 25;

    [Header("Timers")] 
    public float timer;
    public float timerOfFourthRaw;

    void Start()
    {
        zoomOutButton.gameObject.SetActive(false);
        zoomOutButton.onClick.AddListener(ZoomOutClicked);
        featuresWindow.SetActive(false);
    }

    void ZoomOutClicked()
    {
        ZoomOut?.Invoke();
    }
}