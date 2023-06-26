using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(ClickAnimation))]
public class ClickHandler : MonoBehaviour
{
    public float currentPps;

    [HideInInspector]
    public ClickAnimation clickAnim;

    private void Awake()
    {
        clickAnim = this.GetComponent<ClickAnimation>();
    }


    public void ClickAnimate() => clickAnim.ClickAnimate();


}

