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

    public Dictionary<Generator, InventoryInfo> generatorInventory;
    public InventoryInfo generatorInventoryInfo;

    ClickManager clickManager;
    ClickHandler clickHandler;

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
        
        generatorInventory = new Dictionary<Generator, InventoryInfo>();
        clickManager = this.GetComponent<ClickManager>();
        clickHandler = this.GetComponent<ClickHandler>();
    }

    //PROVISORIO
    private void Update()
    {
        PricesFlush();
    }


    public void PricesFlush() 
    { 
        foreach(var generatorObject in generatorInventory)
        {
            if(generatorObject.Value.currentCost > clickManager.totalAmount)
            {
                generatorObject.Key.playerHasEnoughCredits = false;
            }

            else
            {
                generatorObject.Key.playerHasEnoughCredits = true;
            }

        }

    }

    #region ADD
    public void AddGenerator(Generator generatorObject)
    {
        
        //provisorio
        if (generatorObject._firstBuy) generatorObject._firstBuy = false;


        var generator = generatorObject.generatorConfigs;

        //SERA UTIL PARA QUANDO TIVER COMPRA EM LOTE, PODE VIRAR UM PARAMETRO DA FUNCAO
        //TIPO EM COMPRAS QUE QUEIRA FAZER COMPRANDO LOTE DE 1x, 10x, 100x
        int quantity = 1;

        if (generatorInventory.ContainsKey(generatorObject))
        {
            var selectedGenerator = generatorInventory[generatorObject];

            clickManager.totalAmount -= selectedGenerator.currentCost;
            
            selectedGenerator.quantity += quantity;

            var newValues = CalculateGenerator(selectedGenerator, generator);

            generatorInventory[generatorObject].currentCost = newValues.currentCost; //_____________ALGUMA CONTA PARA CALCULAR NOVO COST;
            generatorInventory[generatorObject].currentPps = newValues.currentPps; //_____________ALGUMA CONTA PARA CALCULAR NOVO PPS;
        }
        else
        {
            clickManager.totalAmount -= generator.baseCost;
            //Debug.Log($"Preço inicial de {generator.name} | { generator.baseCost }");  //NAO FAZ SENTIDO, ESSE EH O PRECO ANTERIOR

            generatorInventory.Add(
                generatorObject, 
                new InventoryInfo() { 
                    quantity = quantity,
                    currentCost = generator.baseCost,   //TALVEZ CALCULAR NOVO COST aqui tbm, pois assim o 2o gerador ja tera custo diferente.
                    currentPps = generator.basePps
                }
            );
        }

        var newPrice = generatorInventory[generatorObject].currentCost;
        var newQuantity = generatorInventory[generatorObject].quantity;
        
        //Debug.Log($"Preço de {generator.name} | { newPrice.ToString("F0") }");
        Debug.Log($"Quantidade de {generator.name} | {newQuantity.ToString("F0")}");

        generatorObject.UpdatePrice(newPrice);
        generatorObject.UpdateQuantity(newQuantity);
        clickHandler.RecalculateAllValues();

    }

    public void AddGeneratorUpgrade(Generator generatorObject, UpgradeSO upgrade)
    {
        if (generatorInventory.ContainsKey(generatorObject))
        {
            generatorInventory[generatorObject].currentUpgrade = upgrade;
            //generatorInventory[generator].currentPps = //ALGUMA CONTA PARA CALCULAR NOVO PPS, POREEEM BASEADA NO UPGRADE;
        }
        else
        {
            //REVER TRECHO
            //TALVEZ EXIBIR ERRO DE QUE NAO EH POSSIVEL COMPRAR UM UPGRADE DE UM GENERATOR QUE VOCE NAO POSSUI
            //Assim pode se evitar problemas de cheats e glitches
            generatorInventory.Add(
                generatorObject,
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

