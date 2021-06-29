using System;
using System.Collections.Generic;
using System.Linq;

namespace LeetCodeTasks
{
    class HowManyNumbersAreSmallerThantheCurrentNumber_1365
    {
        public int[] SmallerNumbersThanCurrent(int[] nums)
        {
            Dictionary<int, int> enteredNums = new Dictionary<int, int>();
            int[] result = new int[nums.Length];

            foreach (int i in nums)
            {
                if (enteredNums.ContainsKey(i))
                    enteredNums[i]++;
                else
                    enteredNums[i] = 1;
            }

            int[] keys = enteredNums.Keys.ToArray();
            Array.Sort(keys);

            int count = 0;
            for (int i = 0; i < keys.Length; i++)
            {
                count += enteredNums[keys[i]];
                enteredNums[keys[i]] = count - enteredNums[keys[i]];
            }

            for (int i = 0; i < nums.Length; i++)
            {
                result[i] = enteredNums[nums[i]];
            }

            return result;
        }
    }
}
