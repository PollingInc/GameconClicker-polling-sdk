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
            this.gameObject = target;
            this.onSuccess = onSuccess;
            this.onFailure = onFailure;
            this.onReward = onReward;
            this.onSurveyAvailable = onSurveyAvailable;

            this.callbackHandler = Bridge.CallbackHandler(target.name,
                onSuccess.Method.Name, onFailure.Method.Name,
                onReward.Method.Name, onSurveyAvailable.Method.Name);
        }
    }
}