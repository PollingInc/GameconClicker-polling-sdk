using UnityEngine;

namespace Polling { 

    public class SdkPayload
    {
        public RequestIdentification requestIdentification;
        public CallbackHandler callbackHandler;
        public bool disableAvailableSurveysPoll;

        public AndroidJavaObject sdkPayload;


        public SdkPayload(RequestIdentification requestIdentification, CallbackHandler callbackHandler, bool disableAvailableSurveysPoll)
        {
            this.requestIdentification = requestIdentification;
            this.callbackHandler = callbackHandler;
            this.disableAvailableSurveysPoll = disableAvailableSurveysPoll;

            sdkPayload = Bridge.SdkPayload(requestIdentification.requestIdentification, callbackHandler.callbackHandler, disableAvailableSurveysPoll);
        }

    }

}