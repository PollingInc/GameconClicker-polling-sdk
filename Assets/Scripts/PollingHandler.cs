using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Polling;
using System;


public class PollingHandler : MonoBehaviour
{
    public Animator pollingButton;
    RequestIdentifier requestIdentifier;

    public void Initialize()
    {
        
        if (!FlutterBridge.IsInitialized())
        {
            FlutterBridge.Initialize();
            requestIdentifier = new(UnityEngine.Random.Range(1, 1000).ToString(), "cli_wZJW1tH39TfUMbEumPLrDy15EXDqJA0a");
        }
        
    }


    public void ToggleButton()
    {
        pollingButton.SetBool("toggle", !pollingButton.GetBool("toggle"));
    }


    public void PopupSurveyDialog()
    {
        if (!FlutterBridge.IsInitialized()) return;

        FlutterBridge.AvailableSurveysWithViewType(UnityEngine.Random.Range(1, 1000).ToString(), "cli_wZJW1tH39TfUMbEumPLrDy15EXDqJA0a", (int)ViewType.Dialog);
    }

    public void PopupSurveyBottom()
    {
        if (!FlutterBridge.IsInitialized()) return;

        FlutterBridge.AvailableSurveysWithViewType(UnityEngine.Random.Range(1, 1000).ToString(), "cli_wZJW1tH39TfUMbEumPLrDy15EXDqJA0a", (int)ViewType.Bottom);
    }



    /*
    public void PopupSurveyDialog()
    {
        // Replace with actual customerId and apiKey
        FlutterBridge.AvailableSurveysWithViewType(requestIdentifier.customerId, requestIdentifier.apiKey, (int)ViewType.Dialog);
    }

    public void PopupSurveyBottom()
    {
        FlutterBridge.AvailableSurveysWithViewType(requestIdentifier.customerId, requestIdentifier.apiKey, (int)ViewType.Bottom);
    }
    */




    public void ShowSingleSurvey(string surveyId)
    {
        if (!FlutterBridge.IsInitialized()) return;
        FlutterBridge.SingleSurveyWithViewType(surveyId, requestIdentifier.customerId, requestIdentifier.apiKey, (int)ViewType.Bottom);
    }

    public void OnFlutterMessageReceived(string message)
    {
        if (!FlutterBridge.IsInitialized()) return;
        FlutterBridge.ReceiveCallbackFromFlutter(message);
    }
}


public class RequestIdentifier
{
    public string customerId;
    public string apiKey;

    public RequestIdentifier(string customerId, string apiKey)
    {
        this.customerId = customerId;
        this.apiKey = apiKey;

    }
}




/*
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
        apiKey = "app_JDcvivKMJYiOT8fdyII6Dy9T5ug26BJ6";
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
*/