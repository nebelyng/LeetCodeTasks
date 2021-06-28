using System;
using System.Collections.Generic;

namespace LeetCodeTasks
{
    class NumberofGoodPairs_1512
    {
        public int NumIdenticalPairs(int[] nums)
        {
            int countPairs = 0;
            Dictionary<int, int> countNum = new Dictionary<int, int>();
            foreach (int i in nums)
            {
                if (countNum.ContainsKey(i))
                    countNum[i]++;
                else
                    countNum[i] = 1;
            }

            foreach(int val in countNum.Values)
            {
                countPairs += val * (val - 1) / 2;
            }
            return countPairs;
        }
    }
}
