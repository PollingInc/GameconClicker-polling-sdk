using System;
using UnityEngine;

namespace Polling { 

    public enum ViewType
    {
        None = 0 ,
        Dialog = 1,
        Bottom = 2
    }

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


    public class Survey
    {

        private AndroidJavaObject survey;

        public Survey(RequestIdentification requestIdentification, CallbackHandler callbackHandler)
        {
            survey = new AndroidJavaObject("com.polling.sdk.Survey", requestIdentification.requestIdentification, callbackHandler.callbackHandler);
        }

        public void AvailableSurveys()
        {
            survey.Call("availableSurveys");
        }

        public void AvailableSurveys(ViewType viewType)
        {
            survey.Call("availableSurveys", Bridge.UnityActivity(), viewType.ToString());
        }


        public void SingleSurvey(string surveyId)
        {
            survey.Call("singleSurvey", surveyId);
        }

        public void SingleSurvey(string surveyId, ViewType viewType)
        {
            survey.Call("singleSurvey", surveyId, Bridge.UnityActivity(), viewType.ToString());
        }


        public void CompletedSurveys()
        {
            survey.Call("completedSurveys");
        }
    }
}