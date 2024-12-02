using UnityEngine;

namespace Polling
{

    internal static class Bridge
    {
        internal static AndroidJavaObject UnityActivity()
        {
            var unityActivity = new AndroidJavaClass("com.unity3d.player.UnityPlayer").GetStatic<AndroidJavaObject>("currentActivity");
            return unityActivity;
        }

        #region REQUEST

        internal static AndroidJavaObject DialogRequest(string customerId, string apiKey)
        {
            if (customerId == null || apiKey == null) return null;

            return new AndroidJavaObject("com.polling.sdk.DialogRequest", UnityActivity(), customerId, apiKey);
        }


        internal static AndroidJavaObject RequestIdentification(string customerId, string apiKey)
        {
            if (customerId == null || apiKey == null) return null;

            return new AndroidJavaObject("com.polling.sdk.RequestIdentification", customerId, apiKey);
        }
        #endregion REQUEST
    }

}