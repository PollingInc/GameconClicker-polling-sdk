using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using System.Linq;

public class EconomyHandler : MonoBehaviour
{
    public List<EconomyAsset> economyAssets;

    public void UpdateEconomyAssetValue(EconomyType economyType, int amount) 
    {
        var target = economyAssets.Where(asset => asset.economyType == economyType).First();
        target.amountText.text = amount.ToString();
    }
}
