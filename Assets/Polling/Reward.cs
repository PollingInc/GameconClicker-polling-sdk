using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Polling
{
    [System.Serializable]
    public class Reward
    {
        public string reward_amount;
        public string reward_name;

        public static List<Reward> Deserialize(string jsonArray)
        {
            string json = "{\"rewards\":" + jsonArray + "}";
            var rewards = JsonUtility.FromJson<RewardList>(json);
            return rewards.rewards;
        }
    }

    class RewardList
    {
        public List<Reward> rewards;
    }
}
