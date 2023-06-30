using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Generator : MonoBehaviour
{
    public GeneratorSO generatorConfigs;
    public TMP_Text priceField;

    public void Awake()
    {
        priceField.text = generatorConfigs.baseCost.ToString("F0");
    }

    public void Add()
    {
        var inventoryManager = InventoryManager.Instance;
        var clickManager = ClickManager.Instance;
        
        if(inventoryManager == null || clickManager == null)
        {
            Debug.LogWarning($"{inventoryManager.name ?? clickManager.name} nao encontrado");
            return;
        }

        inventoryManager.AddGenerator(generatorConfigs, this);
    }

    public void UpdatePrice(float newPrice)
    {
        priceField.text = newPrice.ToString("F0");
    }


}
