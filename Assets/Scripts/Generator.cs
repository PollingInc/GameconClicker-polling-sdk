using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Generator : MonoBehaviour
{
    public GeneratorSO generatorConfigs;
    public TMP_Text quantityField;
    public TMP_Text priceField;

    public bool playerHasEnoughCredits = false;
    
    //provisoria
    public bool _firstBuy = true;

    Button buyButton;


    public void Awake()
    {
        priceField.text = generatorConfigs.baseCost.ToString("F0");
        quantityField.text = 0.ToString("F0");
        buyButton = this.GetComponent<Button>();
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

        inventoryManager.AddGenerator(this);
    }

    //PROVISORIO PARA A ENTREGA DO EVENTO
    private void Update()
    {
        //EM ALGUM LUGAR, TALVEZ EXTERNO, TEM QUE ENTRAR A LOGICA QUE MUDA O buyButton


        if (playerHasEnoughCredits)
        {
            if (!buyButton.interactable) EnableBuyButton();
        }
        else 
        {
            if (_firstBuy) 
            {
                if (ClickManager.Instance.totalAmount >= generatorConfigs.baseCost) 
                {
                    EnableBuyButton();
                    return;
                }
            }

            DisableBuyButton();
        }
    }


    public void EnableBuyButton()
    {
        buyButton.interactable = true;
    }

    public void DisableBuyButton()
    {
        buyButton.interactable = false;
    }


    public void UpdatePrice(float newPrice)
    {
        priceField.text = newPrice.ToString("F0");
    }

    public void UpdateQuantity(int newQuantity)
    {
        quantityField.text = newQuantity.ToString("F0");
    }


}
