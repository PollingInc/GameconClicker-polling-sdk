using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ClickAnimation))]
public class ClickHandler : MonoBehaviour
{
    
    public float currentPps;
    private float currentClick;

    public float staticModifier = 1.07f; //1.07f



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


    public float CalculateClickValue()
    {
        //essa linha sera comentada e so esta aqui para ter um valor calculado qualquer para testar apenas
        currentClick = Mathf.Floor(currentPps * staticModifier * levelManager.currentLevel / 1.07f);

        //sera global
        List<KeyValuePair<GeneratorSO, int>> inventory = new List<KeyValuePair<GeneratorSO,int>>();

        //sera global
        float totalPps = 0;

        //mantera local
        float _totalPps = 0;

        foreach (var generator in inventory)
        {
            _totalPps += generator.Key.currentPps * generator.Value;
        }

        totalPps = _totalPps;


        return currentClick;
    }



    //public void ClickAnimate() => clickAnim.ClickAnimate();


}

