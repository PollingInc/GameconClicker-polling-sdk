using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public enum EconomyType
{
    Coins,
    Rubies
}

public class EconomyAsset : MonoBehaviour
{
    public EconomyType economyType;
    public TMP_Text amountText;
}
