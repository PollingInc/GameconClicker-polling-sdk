using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Polling { 

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


    public class Request
    {
    
        public DialogRequest DialogRequest(string customerId, string apiKey)
        {
            var javaObj = Bridge.DialogRequest(customerId, apiKey);

            DialogRequest dialogRequest = new();

            dialogRequest.activity = javaObj.Get<AndroidJavaObject>("activity");
            dialogRequest.customerId = javaObj.Get<string>("customerId");
            dialogRequest.apiKey = javaObj.Get<string>("apiKey");
            dialogRequest.dialogRequest = javaObj;

            return dialogRequest;

        }



        public RequestIdentification RequestIdentification(string customerId, string apiKey)
        {
            var javaObj = Bridge.RequestIdentification(customerId, apiKey);

            RequestIdentification requestIdentification = new();

            requestIdentification.customerId = javaObj.Get<string>("customerId");
            requestIdentification.apiKey = javaObj.Get<string>("apiKey");
            requestIdentification.requestIdentification = javaObj;

            return requestIdentification;
        }
    }

}
