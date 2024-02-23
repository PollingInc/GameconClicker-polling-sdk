using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PollingHandler : MonoBehaviour
{
    public void PopupSurvey() 
    {
        using (var unityActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity"))
        {
            using (var webViewDialogHelper = new AndroidJavaClass("com.polling.sdk.WebViewDialogHelper"))
            {
                Debug.Log("Opening Java WebView dialog...");
                webViewDialogHelper.CallStatic("showDialog", unityActivity);
            }
        }
    }
}
