using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GeneratorSO generatorConfigs;
    
    public void Add()
    {
        var inventoryManager = InventoryManager.Instance;
        var clickManager = ClickManager.Instance;
        
        if(inventoryManager == null || clickManager == null)
        {
            Debug.LogWarning($"{inventoryManager.name ?? clickManager.name} nao encontrado");
            return;
        }

        inventoryManager.AddGenerator(generatorConfigs);
    }

}
