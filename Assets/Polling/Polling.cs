using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct RequestIdentification
{
    public string customerId;
    public string apiKey;
    public AndroidJavaObject requestIdentification;
}
public struct DialogRequest
{
    public AndroidJavaObject activity;
    public string customerId;
    public string apiKey;
    public AndroidJavaObject dialogRequest;

}


public class Polling
{

    private AndroidJavaObject UnityActivity()
    {
        var unityActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
        return unityActivity;
    }


    
    public DialogRequest DialogRequest(string customerId, string apiKey)
    {
        var javaObj = DialogRequestJava(customerId, apiKey);

        DialogRequest dialogRequest = new();

        dialogRequest.activity = javaObj.Get<AndroidJavaObject>("activity");
        dialogRequest.customerId = javaObj.Get<string>("customerId");
        dialogRequest.apiKey = javaObj.Get<string>("apiKey");
        dialogRequest.dialogRequest = javaObj;

        return dialogRequest;

    }


    private AndroidJavaObject DialogRequestJava(string customerId, string apiKey)
    {
        if (customerId == null || apiKey == null)
        {
            Debug.LogError("Null identificator was passed");
        }

        return new AndroidJavaObject("com.polling.sdk.DialogRequest", UnityActivity(), customerId, apiKey);
    }


    public RequestIdentification RequestIdentification(string customerId, string apiKey)
    {
        var javaObj = RequestIdentificationJava(customerId, apiKey);

        RequestIdentification requestIdentification = new();

        requestIdentification.customerId = javaObj.Get<string>("customerId");
        requestIdentification.apiKey = javaObj.Get<string>("apiKey");
        requestIdentification.requestIdentification = javaObj;

        return requestIdentification;
    }

    private AndroidJavaObject RequestIdentificationJava(string customerId, string apiKey)
    {
        if (customerId == null || apiKey == null)
        {
            Debug.LogError("Null identificator was passed");
        }

        return new AndroidJavaObject("com.polling.sdk.RequestIdentification", customerId, apiKey);
    }





}
