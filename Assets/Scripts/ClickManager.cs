using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[RequireComponent(typeof(ClickHandler))]

[RequireComponent(typeof(ClickAnimation))]

public class ClickManager : MonoBehaviour
{
    public static ClickManager Instance { get; private set; }

    public float totalAmount;
    public TMP_Text amountDisplay;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }


    public float AddAmount(float amount)
    {
        totalAmount += amount;
        return totalAmount;
    }

    void Update()
    {
        if(amountDisplay == null)
        {
            Debug.LogWarning("NULL CHECK - Amount display não configurado - TMPro");
            return;
        }


        amountDisplay.text = totalAmount.ToString("F0");
    }




}
