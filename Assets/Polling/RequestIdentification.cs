using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Polling { 

    public class RequestIdentification
    {
        private string customerId;
        private string apiKey;

        public AndroidJavaObject requestIdentification;

        public RequestIdentification(string customerId, string apiKey)
        {
           var javaObj = Bridge.RequestIdentification(customerId, apiKey);

           this.customerId = javaObj.Get<string>("customerId");
           this.apiKey = javaObj.Get<string>("apiKey");

           requestIdentification = javaObj;
        }
    }

}
