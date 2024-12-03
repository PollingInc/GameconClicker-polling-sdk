using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Polling 
{
    public class Polling
    {

        AndroidJavaObject polling;

        public Polling()
        {
            polling = Bridge.Polling();
        }


        public void Initialize(SdkPayload sdkPayload)
        {
            polling.Call("initialize", sdkPayload.sdkPayload);
        }


        public void SetCustomerId(string customerId)
        {
            polling.Call("setCustomerId", customerId);
        }

        public void SetApiKey(string apiKey)
        {
            polling.Call("setApiKey", apiKey);
        }

        public void SetViewType(ViewType viewType) 
        {
            polling.Call("setViewType", viewType.ToString());
        }



        public void LogPurchase(int integerCents)
        {
            polling.Call("logPurchase", integerCents);
        }


        public void LogSession()
        {
            polling.Call("logSession");
        }

        
        public void LogEvent(string eventName, string eventValue)
        {
            polling.Call("logEvent", eventName, eventValue);
        }

        public void LogEvent(string eventName, int eventValue)
        {
            polling.Call("logEvent", eventName, eventValue.ToString());
        }

        public void ShowSurvey(string surveyUuid)
        {
            polling.Call("showSurvey", surveyUuid, Bridge.UnityActivity());
        }

        public void ShowEmbedView()
        {
            polling.Call("showEmbedView", Bridge.UnityActivity());
        }

        /*
        public List<string> GetLocalSurveyResults(string surveyUuid)
        {
            return localStorage.getItem(surveyUuid);
        }
        */

    }
}