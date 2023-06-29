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
    public static InventoryManager Instance { get; private set; }

    public Dictionary<GeneratorSO, InventoryInfo> generatorInventory;
    public InventoryInfo generatorInventoryInfo;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
        
        generatorInventory = new Dictionary<GeneratorSO, InventoryInfo>();
    }

    #region ADD
    public void AddGenerator(GeneratorSO generator)
    {
        if(generatorInventory.ContainsKey(generator))
        {
            var selectedGenerator = generatorInventory[generator];
            selectedGenerator.quantity += 1;

            var newValues = CalculateGenerator(selectedGenerator, generator);

            selectedGenerator.currentCost = newValues.currentCost; //_____________ALGUMA CONTA PARA CALCULAR NOVO COST;
            generatorInventory[generator].currentPps = newValues.currentPps; //_____________ALGUMA CONTA PARA CALCULAR NOVO PPS;
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

    #endregion ADD

    #region CALCULATE
    public InventoryInfo CalculateGenerator(InventoryInfo currentValues, GeneratorSO generator)
    {
        //PPS FORMULA
        var newPps = generator.basePps * currentValues.quantity;

        //COST FORMULA
        var newCost = generator.baseCost * (Mathf.Pow(1.07f, currentValues.quantity));


        currentValues.currentPps = newPps;
        currentValues.currentCost = newCost;

        return currentValues;

    }
    #endregion CALCULATE



}

