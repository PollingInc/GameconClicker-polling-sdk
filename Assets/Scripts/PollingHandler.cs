
using Polling;
using System;
using System.Collections.Generic;
using UnityEngine;

public class PollingHandler : MonoBehaviour
{

    public Animator pollingButton;
    public EconomyHandler economyHandler;

    public string customerId;
    private string apiKey;

    Polling.Polling polling;


    public void InfoSetup()
    {
        customerId = "unityTest" + UnityEngine.Random.Range(1, 1000).ToString();
        apiKey = "H3uZsrv6B2qyRXGePLxQ9U8g7vilWFTjIhZO";
    }

    public void ToggleButton()
    {
        pollingButton.SetBool("toggle", !pollingButton.GetBool("toggle"));
    }

    void Start()
    {
        InfoSetup();

        RequestIdentification request = new RequestIdentification(customerId, apiKey);
        CallbackHandler callbacks = new CallbackHandler(this.gameObject, OnSuccess, OnFailure, OnReward, OnSurveyAvailable);

        SdkPayload sdkPayload = new SdkPayload(request, callbacks, false);

        polling = new Polling.Polling();
        polling.Initialize(sdkPayload);
    }

    //----------------------------------------------------------------------------------------------------------------
    private void OnSuccess(string response)
    {
        Debug.Log("SUCCESS (Unity): " + response);
    }

    private void OnFailure(string error)
    {
        Debug.Log("ERROR (Unity): " + error);
    }

    private void OnReward(string response)
    {
        Debug.Log("REWARD (Unity): " + "JSON - " + response);

        Reward reward = Reward.Deserialize(response);
        HandleReward(reward);
    }

    private void OnSurveyAvailable()
    {
        Debug.Log("(Unity) There is a survey available.");
    }

    //----------------------------------------------------------------------------------------------------------------
    void HandleReward(Reward reward)
    {
        Debug.Log($"(Unity) Reward: {reward.reward_name} | {reward.reward_amount}");

        bool nameSuccess = Enum.TryParse(reward.reward_name, out EconomyType type);
        bool valueSuccess = int.TryParse(reward.reward_amount, out int amount);

        if (nameSuccess && valueSuccess)
        {
            economyHandler.UpdateEconomyAssetValue(type, amount);
        }
    }

    //----------------------------------------------------------------------------------------------------------------
    public void PopupSurveyBottom()
    {
        polling.SetViewType(ViewType.Bottom);
        polling.LogEvent("unityTest", 1);
    }
    public void PopupSurveyDialog()
    {
        polling.SetViewType(ViewType.Dialog);
        polling.LogEvent("unityTest", 1);
    }
}