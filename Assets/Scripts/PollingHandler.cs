using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Polling;
using System;

public class PollingHandler : MonoBehaviour
{

    public Animator pollingButton;
    public EconomyHandler economyHandler;

    public string customerId;
    private string apiKey;
    Survey survey;


    public void InfoSetup()
    {
        customerId = UnityEngine.Random.Range(1, 1000).ToString();
        apiKey = "cli_wZJW1tH39TfUMbEumPLrDy15EXDqJA0a";
    }

    public void ToggleButton()
    {
        pollingButton.SetBool("toggle", !pollingButton.GetBool("toggle"));
    }

    void Start()
    {
        InfoSetup();

        Identifier request = new Identifier(customerId, apiKey);
        CallbackHandler callbacks = new(this.gameObject, OnSuccess, OnFailure, OnReward);

        survey = new Survey(request, callbacks);
    }


    private void OnSuccess(string response)
    {
        Debug.Log("SUCCESS: " + response);
    }

    private void OnFailure(string error)
    {
        Debug.Log("ERROR: " + error);
    }

    private void OnReward(string response)
    {
        List<Reward> rewards = survey.OnReward(response);
        HandleRewards(rewards);
    }

    void HandleRewards(List<Reward> rewards)
    {
        foreach(Reward reward in rewards)
        {
            bool success = Enum.TryParse(reward.reward_name, out EconomyType type);
            success = int.TryParse(reward.reward_amount, out int amount);

            if (success)
            {
                economyHandler.UpdateEconomyAssetValue(type, amount);
            }
            
        }
        
    }


    public void AvailableSurveysApi()
    {
        survey.AvailableSurveys();
    }
    public void PopupSurveyBottom()
    {
        survey.AvailableSurveys(ViewType.Bottom);
    }
    public void PopupSurveyDialog()
    {
        survey.AvailableSurveys(ViewType.Dialog);
    }
}
