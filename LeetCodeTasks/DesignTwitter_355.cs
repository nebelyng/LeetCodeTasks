using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTasks
{
    public class Twitter
    {
        public List<int> tweets;
        public Dictionary<int, List<int>> userTweets;
        public Dictionary<int, List<int>> folowers;

        /** Initialize your data structure here. */
        public Twitter()
        {
            tweets = new List<int>();
            userTweets = new Dictionary<int, List<int>>();
            folowers = new Dictionary<int, List<int>>();

        }

        /** Compose a new tweet. */
        public void PostTweet(int userId, int tweetId)
        {
            if (!folowers.ContainsKey(userId))
            {
                folowers[userId] = new List<int>();
                folowers[userId].Add(userId);
            }

            if (!userTweets.ContainsKey(userId))
            {
                userTweets[userId] = new List<int>();
            }
            userTweets[userId].Add(tweetId);
            tweets.Add(tweetId);
        }

        /** Retrieve the 10 most recent tweet ids in the user's news feed. Each item in the news feed must be posted by users who the user followed or by the user herself. Tweets must be ordered from most recent to least recent. */
        public IList<int> GetNewsFeed(int userId)
        {
            List<int> allTweets = new List<int>();
            if (folowers.ContainsKey(userId))
            {
                foreach (int follow in folowers[userId])
                {
                    if (userTweets.ContainsKey(follow))
                    {
                        allTweets.AddRange(userTweets[follow]);
                    }
                }
                List<int> result = tweets.Where(x => allTweets.Contains(x)).ToList();
                result.Reverse();
                return result.Take(10).ToList();
            }
            else
            {
                return new List<int>();
            }
        }

        /** Follower follows a followee. If the operation is invalid, it should be a no-op. */
        public void Follow(int followerId, int followeeId)
        {
            if (!folowers.ContainsKey(followerId))
            {
                folowers[followerId] = new List<int>();
                folowers[followerId].Add(followerId);
            }
            folowers[followerId].Add(followeeId);
        }

        /** Follower unfollows a followee. If the operation is invalid, it should be a no-op. */
        public void Unfollow(int followerId, int followeeId)
        {
            if (folowers.ContainsKey(followerId) && followerId != followeeId)
            {
                folowers[followerId].Remove(followeeId);
            }
        }
    }
}
