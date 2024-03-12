using System;
using UnityEngine;

namespace Polling { 

    public enum ViewType
    {
        None,
        Dialog,
        Bottom
    }

    public class CallbackHandler
    {
        public Action onSuccess;
        public Action onFailure;
        public AndroidJavaObject callbackHandler;

        public CallbackHandler(GameObject target, Action onSuccess, Action onFailure)
        {
            var callbackHandler = new AndroidJavaObject("com.polling.sdk.UnityCallbackHandler", target.name, onSuccess.ToString(), onFailure.ToString());

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
            survey = new AndroidJavaObject("com.polling.sdk.Survey", requestIdentification, callbackHandler.callbackHandler);
        }

        public void AvailableSurveys()
        {
            survey.Call("availableSurveys");
        }

        public void AvailableSurveys(ViewType viewType)
        {
            survey.Call("availableSurveys", Bridge.UnityActivity(), viewType);
        }


        public void SingleSurvey(string surveyId)
        {
            survey.Call("singleSurvey", surveyId);
        }

        public void SingleSurvey(string surveyId, ViewType viewType)
        {
            survey.Call("singleSurvey", surveyId, Bridge.UnityActivity(), viewType);
        }


        public void CompletedSurveys()
        {
            survey.Call("completedSurveys");
        }
    }
}