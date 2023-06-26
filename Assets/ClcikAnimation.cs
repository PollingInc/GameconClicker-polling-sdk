using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAnimation : MonoBehaviour
{

    public List<Animation> currentInDisplay;

    public void ClickAnimate() => currentInDisplay.ForEach((Animation a) => a.Play());

}
