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
    public TMP_Text ppsDisplay;

    LevelManager levelManager;
    ClickHandler clickHandler;

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

        //TEMPORARIO PARA EVENTO

        levelManager = this.GetComponent<LevelManager>();
        clickHandler = this.GetComponent<ClickHandler>();
    }


    public float AddAmount(float amount)
    {
        totalAmount += amount;

        if (!levelManager.currentLevel.isConcluded) {
            var currentLevel = levelManager.currentLevel;
            currentLevel.currentCumulative += amount;

            if (currentLevel.currentCumulative > currentLevel.cumulativeGoal) {
                levelManager.UnlockNextLevel();
            }
        }
        


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
        ppsDisplay.text = clickHandler.currentPps.ToString("F0") + " pps";
    }




}
