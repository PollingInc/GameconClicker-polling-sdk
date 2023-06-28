using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public Dictionary<GeneratorSO, InventoryInfo> generatorInventory;
    public InventoryInfo generatorInventoryInfo;


    private void Awake()
    {
        generatorInventory = new Dictionary<GeneratorSO, InventoryInfo>();
    }


    public void AddGenerator(GeneratorSO generator)
    {
        if(generatorInventory.ContainsKey(generator))
        {
            generatorInventory[generator].quantity += 1;
        }
        else
        {
            generatorInventory.Add(
                generator, 
                new InventoryInfo() { 
                    quantity = 1 
                }
                );
        }
    }

    public void AddGeneratorUpgrade()
    {

    }



}
public class InventoryInfo
{
    public int quantity;
    public float currentCost;
    public float currentPps;
    public UpgradeSO currentUpgrade;
}
