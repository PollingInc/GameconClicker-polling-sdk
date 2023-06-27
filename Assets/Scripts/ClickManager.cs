using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


[RequireComponent(typeof(ClickHandler))]

[RequireComponent(typeof(ClickAnimation))]

public class ClickManager : MonoBehaviour
{
    public float totalAmount;
    public TMP_Text amountDisplay;
        
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
