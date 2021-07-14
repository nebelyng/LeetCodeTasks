using System;
using System.Linq;

namespace LeetCodeTasks
{
    class ReverseWordsInAString_151
    {
        public string ReverseWords(string s)
        {
            return string.Join(' ', s.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Reverse());
        }
    }
}
