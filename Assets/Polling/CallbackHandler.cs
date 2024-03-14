using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Polling
{
    public class CallbackHandler
    {
        public Action<string> onSuccess;
        public Action<string> onFailure;
        public AndroidJavaObject callbackHandler;

        public CallbackHandler(GameObject target, Action<string> onSuccess, Action<string> onFailure)
        {
            var callbackHandler = new AndroidJavaObject("com.polling.sdk.UnityCallbackHandler", target.name, onSuccess.Method.Name, onFailure.Method.Name);

            this.onSuccess = onSuccess;
            this.onFailure = onFailure;

            this.callbackHandler = callbackHandler;
        }
    }
}