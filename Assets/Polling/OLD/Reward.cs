using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Polling
{
    [System.Serializable]
    public class Reward
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
    }
}
