using System;
using System.Collections.Generic;
using UnityEngine;

namespace Polling { 

    public enum ViewType
    {
        None = 0 ,
        Dialog = 1,
        Bottom = 2
    }

    public class Survey
    {

        private AndroidJavaObject survey;
        private CallbackHandler callbackHandler;
        private CallbackHandler rewardCallback;
        public Survey(RequestIdentification identifier, CallbackHandler callbackHandler)
        {
            survey = new AndroidJavaObject("com.polling.sdk.Survey", identifier.requestIdentification, callbackHandler.callbackHandler);
            this.callbackHandler = callbackHandler;

            this.rewardCallback = new CallbackHandler(callbackHandler.gameObject, callbackHandler.onReward, callbackHandler.onFailure, callbackHandler.onReward, callbackHandler.onSurveyAvailable);
        }

        public void AvailableSurveys()
        {
            survey.Call("availableSurveys");
        }

        public void AvailableSurveys(ViewType viewType)
        {
            RewardSetup();
            survey.Call("availableSurveys", Bridge.UnityActivity(), viewType.ToString());
        }


        public void SingleSurvey(string surveyId)
        {
            survey.Call("singleSurvey", surveyId);
        }

        public void SingleSurvey(string surveyId, ViewType viewType)
        {
            RewardSetup();
            survey.Call("singleSurvey", surveyId, Bridge.UnityActivity(), viewType.ToString());
        }


        public void CompletedSurveys()
        {
            survey.Call("completedSurveys");
        }


        private void RewardSetup()
        {
            var currentCallback = survey.Get<AndroidJavaObject>("callbackHandler");
            if (currentCallback == rewardCallback.callbackHandler)
            {
                Debug.Log("RewardSetup - Same callback for rewards. Skipping...");
                return;
            }
            else
            {
                Debug.Log("RewardSetup - Not the same callback for rewards. Updating...");
            }

            survey.Call("updateCallbacks", rewardCallback.callbackHandler);
            Debug.Log("Updated!");
        }


        public List<Reward> OnReward(string response)
        {

            Debug.Log("OnReward running.");

            //List<Dictionary<string, string>> surveys = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(response);
            RewardList rewardList = new();
            List<Reward> rewards = DeserializeSurveys(response);

            foreach (Reward reward in rewards) 
            {
                Debug.Log($"Unity Reward: {reward.reward_name} | {reward.reward_amount}");
            }

            survey.Call("updateCallbacks", callbackHandler.callbackHandler);
            
            return rewards;
        }


        public List<Reward> DeserializeSurveys(string jsonArray)
        {
            string json = "{\"rewards\":" + jsonArray + "}";
            var rewards = JsonUtility.FromJson<RewardList>(json);
            return rewards.rewards;
        }
    }
}