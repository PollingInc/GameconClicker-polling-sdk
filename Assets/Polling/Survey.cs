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

        public Survey(Identifier identifier, CallbackHandler callbackHandler)
        {
            survey = new AndroidJavaObject("com.polling.sdk.Survey", identifier.requestIdentification, callbackHandler.callbackHandler);
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


        private void OnReward(string response)
        {
            //List<Dictionary<string, string>> surveys = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(response);
            RewardList rewardList = new();
            List<Reward> rewards = rewardList.DeserializeSurveys(response);

            foreach (Reward reward in rewards) 
            {
                Debug.Log($"{reward.reward_name} | {reward.reward_amount}");
            }

        }
    }

    class Reward
    {
        public string completed_at;
        public string reward_amount;
        public string reward_name;
        public string name;
        public string started_at;
        public string uuid;
    }

    class RewardList
    {
        public List<Reward> rewards;

        public List<Reward> DeserializeSurveys(string jsonArray)
        {
            string json = "{\"surveys\":" + jsonArray + "}";
            rewards = JsonUtility.FromJson<List<Reward>>(json);
            return rewards;
        }
    }
}