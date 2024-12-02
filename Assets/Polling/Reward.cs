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
    }

    class RewardList
    {
        public List<Reward> rewards;
    }
}
