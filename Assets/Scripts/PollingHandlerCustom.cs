
using Polling;
using System;
using UnityEngine;
using TMPro;
using System.Globalization;

public class PollingHandlerCustom : MonoBehaviour
{

    public GameObject pollingPanel;
    public EconomyHandler economyHandler;

    public string customerId;
    private string apiKey;

    public TMP_InputField logEventInputKey;
    public TMP_InputField logEventInputValue;


    Polling.Polling polling;


    void Awake()
    {
        pollingPanel.SetActive(false);
    }

    public void ToggleButton()
    {
        pollingPanel.SetActive(!pollingPanel.activeInHierarchy);
    }


    //----------------------------------------------------------------------------------------------------------------
    public void InfoSetup()
    {
        if(string.IsNullOrEmpty(customerId))
        {
            customerId = GetUserId();
        }
        
        apiKey = "H3uZsrv6B2qyRXGePLxQ9U8g7vilWFTjIhZO";
    }
    //----------------------------------------------------------------------------------------------------------------
    private string GetUserId()
    {
        return "unityTest" + DateTime.UtcNow.ToString("yyyyMMddHHmmss", CultureInfo.InvariantCulture);
    }



    //----------------------------------------------------------------------------------------------------------------
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
    
    public void ShowSurvey(TMP_InputField uuid)
    {
        polling.ShowSurvey(uuid.text);
    }

    public void ShowEmbed()
    {
        polling.ShowEmbedView();
    }

    //----------------------------------------------------------------------------------------------------------------

    public void LogEvent()
    {
        polling.LogEvent(logEventInputKey.text, logEventInputValue.text);
    }

    public void LogSession()
    {
        polling.LogSession();
    }


    public void LogPurchase(TMP_InputField value)
    {
        string normalizedValue = value.text.Replace(',', '.');

        if (Double.TryParse(normalizedValue, out double result))
        {
            int parsed = (int)(result * 100);
            polling.LogPurchase(parsed);
        }
    }

    //----------------------------------------------------------------------------------------------------------------
    public void SetViewType(string viewTypeStr)
    {
        if(Enum.TryParse(viewTypeStr, out ViewType viewType))
        {
            polling.SetViewType(viewType);
        }   
    }

}
