using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Polling;

public class PollingHandler : MonoBehaviour
{

    public Animator pollingButton;

    public string customerId;
    private string apiKey;
    Survey survey;


    public void InfoSetup()
    {
        customerId = Random.Range(1, 1000).ToString();
        apiKey = "cli_wZJW1tH39TfUMbEumPLrDy15EXDqJA0a";
    }

    public void ToggleButton()
    {
        pollingButton.SetBool("toggle", !pollingButton.GetBool("toggle"));
    }

    void Start()
    {
        InfoSetup();

        Request request = new Request();
        var requestIdentification = request.RequestIdentification(customerId, apiKey);

        CallbackHandler callbacks = new(this.gameObject, OnSuccess, OnFailure);

        survey = new Survey(requestIdentification, callbacks);
    }


    private void OnSuccess(string response)
    {
        Debug.Log("SUCCESS: " + response);
    }

    private void OnFailure(string error)
    {
        Debug.Log("ERROR: " + error);
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





    /*

    private AndroidJavaObject UnityActivity()
    {
        var unityActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        return unityActivity;
    }


    private AndroidJavaObject DialogRequest()
    {
        if(customerId == null || apiKey == null)
        {
            Debug.LogError("Null identificator was passed");
        }

        return new AndroidJavaObject("com.polling.sdk.DialogRequest", UnityActivity(), customerId, apiKey);
    }

    private AndroidJavaObject RequestIdentification()
    {
        if (customerId == null || apiKey == null)
        {
            Debug.LogError("Null identificator was passed");
        }

        return new AndroidJavaObject("com.polling.sdk.RequestIdentification", customerId, apiKey);
    }



    private void OnSuccess(string response)
    {
        Debug.Log("SUCCESS: " + response);
    }

    private void OnFailure(string error)
    {
        Debug.Log("ERROR: " + error);
    }



    public void AvailableSurveysApi() 
    {
        var unityActivity = UnityActivity();

        using (unityActivity)
        {
            using (var requestIdentification = RequestIdentification()) { 

                var callbackHandler = new AndroidJavaObject("com.polling.sdk.UnityCallbackHandler", this.gameObject.name, "OnSuccess", "OnFailure");
                using (var survey = new AndroidJavaObject("com.polling.sdk.Survey", requestIdentification, callbackHandler))
                {
                    Debug.Log("API request for available surveys...");
                    survey.Call("availableSurveys");
                }
            }

        }
    }


    public void PopupSurveyBottom()
    {
        string url = "https://demo.polling.com/sdk/survey/3875c65f-1e7a-411f-b8c3-be2ce19a9c6e";

        var unityActivity = UnityActivity();

        using (unityActivity) 
        {
            Debug.Log("Opening Java WebView bottom sheet for available surveys...");
            AndroidJavaObject webViewBottom = new AndroidJavaObject("com.polling.sdk.WebViewBottomCustom", url, DialogRequest());
            webViewBottom.Call("show");
        }
    }


    public void PopupSurveyDialog() 
    {
        var unityActivity = UnityActivity();

        using (unityActivity)
        {

            var dialogRequest = DialogRequest();

            using (var webViewDialogHelper = new AndroidJavaObject("com.polling.sdk.WebViewDialogHelper", dialogRequest))
            {
                Debug.Log("Opening Java WebView dialog for available surveys...");
                webViewDialogHelper.Call("availableSurveys");
            }
            
        }
    }

    */


}
