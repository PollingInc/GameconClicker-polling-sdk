using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Generator", menuName = "Clicker Modules/Generator", order = 1)]
public class GeneratorSO : ScriptableObject
{
    public float baseCost;
    public float basePps;
    public float costStaticModifier = 1;
    public float ppsStaticModifier = 1;

    public bool autoGenerator;

    //public float currentCost;
    //public float currentPps;
}
