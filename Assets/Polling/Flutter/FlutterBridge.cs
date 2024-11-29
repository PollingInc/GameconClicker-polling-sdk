using Polling;
using System;
using UnityEngine;

public static class FlutterBridge
{

    private static bool initialized = false;

    private static AndroidJavaObject flutterBridge;
    private static AndroidJavaObject unityActivity;   

    public static void Initialize()
    {
        
        try
        {

            Debug.Log("Initializing Flutter Bridge...");
            unityActivity = Bridge.UnityActivity();

            AndroidJavaClass flutterBridgeClass = new AndroidJavaClass("com.polling.sdk_android.UnityBridge");

            flutterBridge = flutterBridgeClass.CallStatic<AndroidJavaObject>("getInstance", unityActivity);

            Debug.Log("Flutter Bridge initialized successfully.");
            initialized = true;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Exception during FlutterBridge initialization: {ex}");
        }
        
        /*
        try
        {

            Debug.Log("Initializing Flutter Bridge...");
            unityActivity = Bridge.UnityActivity();


            flutterBridge = new AndroidJavaObject("com.polling.sdk_android.JavaBridge", unityActivity);

            Debug.Log("Flutter Bridge initialized successfully.");
            initialized = true;
        }
        catch (Exception ex)
        {
            Debug.LogError($"Exception during FlutterBridge initialization: {ex}");
        }
        */
    }


    public static bool IsInitialized()
    {
        if (!initialized) Debug.Log("FlutterBridge not initialized.");
        return initialized;
    }



    /// <summary>
    /// Calls availableSurveysWithViewType in the Flutter library.
    /// </summary>
    public static void AvailableSurveysWithViewType(string customerId, string apiKey, int viewType)
    {
        //flutterBridge.Call("launchFlutterActivity");
        
        flutterBridge.Call("availableSurveysWithViewType", customerId, apiKey, viewType);
        
    }

    /// <summary>
    /// Calls singleSurveyWithViewType in the Flutter library.
    /// </summary>
    public static void SingleSurveyWithViewType(string surveyId, string customerId, string apiKey, int viewType)
    {
        //flutterBridge.Call("singleSurveyWithViewType", surveyId, customerId, apiKey, viewType);
    }

    // Methods to handle Unity-to-Flutter messaging
    public static void SendMessageToFlutter(string methodName, string message)
    {
        //flutterBridge.Call("sendMessageToFlutter", methodName, message);
    }

    // Receive callback from Flutter (called by Unity)
    public static void ReceiveCallbackFromFlutter(string message)
    {
        Debug.Log("Received from Flutter: " + message);
        // Handle callback response
    }
    
}
