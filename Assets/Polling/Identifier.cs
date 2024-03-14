using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Polling { 

    public class Identifier
    {
        private string customerId;
        private string apiKey;
        public AndroidJavaObject requestIdentification;

        public Identifier(string customerId, string apiKey)
        {
           var javaObj = Bridge.RequestIdentification(customerId, apiKey);

           customerId = javaObj.Get<string>("customerId");
           apiKey = javaObj.Get<string>("apiKey");
           requestIdentification = javaObj;
        }
    }

}
