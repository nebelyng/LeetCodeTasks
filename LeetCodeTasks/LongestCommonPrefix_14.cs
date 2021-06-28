using System;
using System.Linq;

namespace LeetCodeTasks
{
    public class LeetCodeTasks
    {
        public string LongestCommonPrefix(string[] strs)
        {

            string prefix = "";
            int minLenth = strs.Min(x => x.Length);

            if (minLenth == 0)
            {
                return prefix;
            }

            for (int j = 0; j < minLenth; j++)
            {
                prefix = String.Concat(prefix, strs[0][j]);

                for (int i = 0; i < strs.Length; i++)
                {
                    if (strs[i][j] != prefix[j])
                    {
                        return prefix.Remove(prefix.Length - 1);
                    }
                }
            }

            return prefix;
        }
    }
}
