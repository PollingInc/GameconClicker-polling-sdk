using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generator : MonoBehaviour
{
    public GeneratorSO generatorConfigs;
    
    public void Add()
    {
        var inventoryManager = InventoryManager.Instance;
        
        if(inventoryManager == null)
        {
            Debug.LogWarning("Inventario nao encontrado");
            return;
        }

        inventoryManager.AddGenerator(generatorConfigs);
    }

}
