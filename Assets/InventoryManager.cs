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

    public void AddGeneratorUpgrade(GeneratorSO generator, UpgradeSO upgrade)
    {
        if (generatorInventory.ContainsKey(generator))
        {
            generatorInventory[generator].currentUpgrade = upgrade;
        }
        else
        {
            //REVER TRECHO
            //TALVEZ EXIBIR ERRO DE QUE NAO EH POSSIVEL COMPRAR UM UPGRADE DE UM GENERATOR QUE VOCE NAO POSSUI
            //Assim pode se evitar problemas de cheats e glitches
            generatorInventory.Add(
                generator,
                new InventoryInfo()
                {
                    quantity = 1,
                    currentUpgrade = upgrade
                }
            );
        }
    }



}
public class InventoryInfo
{
    public int quantity;
    public float currentCost;
    public float currentPps;
    public UpgradeSO currentUpgrade;
}
