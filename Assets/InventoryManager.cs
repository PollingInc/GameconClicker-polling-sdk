using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryInfo
{
    public int quantity;
    public float currentCost;
    public float currentPps;
    public UpgradeSO currentUpgrade;
}


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
            //generatorInventory[generator].currentPps = //ALGUMA CONTA PARA CALCULAR NOVO COST;
            //generatorInventory[generator].currentPps = //ALGUMA CONTA PARA CALCULAR NOVO PPS;
        }
        else
        {
            generatorInventory.Add(
                generator, 
                new InventoryInfo() { 
                    quantity = 1,
                    currentCost = generator.baseCost,   //TALVEZ CALCULAR NOVO COST aqui tbm, pois assim o 2o gerador ja tera custo diferente.
                    currentPps = generator.basePps
                }
            );
        }
    }

    public void AddGeneratorUpgrade(GeneratorSO generator, UpgradeSO upgrade)
    {
        if (generatorInventory.ContainsKey(generator))
        {
            generatorInventory[generator].currentUpgrade = upgrade;
            //generatorInventory[generator].currentPps = //ALGUMA CONTA PARA CALCULAR NOVO PPS, POREEEM BASEADA NO UPGRADE;
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
                    currentUpgrade = upgrade,
                    //currentPps = //ALGUMA CONTA PARA CALCULAR NOVO PPS, POREEEM BASEADA NO UPGRADE
                }
            );
        }
    }



}

