using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ClickAnimation))]
public class ClickHandler : MonoBehaviour
{
    
    public float currentPps;
    private int currentClick;

    public float staticModifier = 1.07f;


    //COMPONENTS

    [HideInInspector]
    public ClickManager clickManager;

    [HideInInspector]
    public ClickAnimation clickAnim;

    [HideInInspector]
    public LevelManager levelManager;

    
    private void Awake()
    {
        clickManager = this.GetComponent<ClickManager>();
        clickAnim = this.GetComponent<ClickAnimation>();
        levelManager = this.GetComponent<LevelManager>();
    }


    public void ClickRoutine()
    {
        clickManager.AddAmount(CalculateClickValue());
        clickAnim.ClickAnimate();
    }


    public int CalculateClickValue()
    {
        currentClick = (int)Mathf.Floor(currentPps * staticModifier * levelManager.currentLevel / 1.07f);
        return currentClick;
    }



    //public void ClickAnimate() => clickAnim.ClickAnimate();


}

