using System;
using UnityEngine;

namespace Polling
{
    public class CallbackHandler
    {
        public GameObject gameObject;
        public Action<string> onSuccess;
        public Action<string> onFailure;
        public Action<string> onReward;
        public Action onSurveyAvailable;

        public AndroidJavaObject callbackHandler;

        public CallbackHandler(GameObject target, Action<string> onSuccess, Action<string> onFailure, Action<string> onReward, Action onSurveyAvailable)
        {
            var callbackHandler = new AndroidJavaObject("com.polling.sdk.UnityCallbackHandler", target.name, onSuccess.Method.Name, onFailure.Method.Name);

            this.gameObject = target;
            this.onSuccess = onSuccess;
            this.onFailure = onFailure;
            this.onReward = onReward;
            this.onSurveyAvailable = onSurveyAvailable;

            this.callbackHandler = callbackHandler;
        }
    }
}