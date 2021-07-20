using System;
using LeetCodeTasks;
using System.Linq;
using System.Collections.Generic;

namespace DebugTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            User[] users = Init();

            /* 
             * 1 comment (user 1) = 'suka blyat mat ebal'
             * 2 commetn (user 1) = 'святоша в чате'
             * 
             * List<string> avadaKedavra = new List<string>() {"suka", "blyat", "zalupa" ...(100)};
             * "suka": List<User> - юзеры, которые употребляли это слово в комментариях
             * "blyat": List<User>
             *...
             */

            List<string> blockListWords = new List<string>() { "suka", "blyat" };


            //найти у кого больше постов среди юзеров 2 done
            //второй снизу по количесту постов 1 done
            //средний возраст юзера 1 done
            //найти всех юзеров которым больше чем 21 1 done
            //найти всех юзеров у которых нет постов 2 done

            //найти юзереров и все коментарии юзеров у которых есть слово блять 4 done
            //ключ текст коментария как 1 из возможных ключей done

            static void AddPost(string header, string textPost, User user)
            {
                Post newPost = new Post() { Header = header, TextPost = textPost, User = user };
                user.Posts.Add(newPost);
            }

            static void AddComm(User user, string textComment, Post comentedPost)
            {
                Comment newComm = new Comment() { User = user, TextComment = textComment };
                comentedPost.Coments.Add(newComm);
            }

            static User[] Init()
            {
                User user = new User();
                User user2 = new User();


                user.Name = "vasya";
                user2.Name = "kolya";

                user.Age = 25;
                user2.Age = 18;

                AddPost("post", "lalala", user);
                AddPost("post2", "lalala", user);
                AddPost("post3", "lalala", user);

                AddPost("post", "lalala", user2);
                AddPost("post2", "lalala", user2);
                AddPost("post3", "lalala", user2);
                AddPost("post4", "lalala", user2);
                AddPost("post5", "lalala", user2);

                AddComm(user, "hahaha1", user.Posts[1]);
                AddComm(user2, "hahaha2", user.Posts[1]);
                AddComm(user, "hahaha3", user.Posts[1]);

                AddComm(user, "hahaha1", user2.Posts[0]);
                AddComm(user2, "hahaha2", user2.Posts[0]);
                AddComm(user, "hahaha3", user2.Posts[0]);

                return new[] { user, user2 };
            }

            User MorestPosts() => users.OrderBy(u => u.Posts.Count()).LastOrDefault();

            User PreLast() => users.OrderBy(u => u.Posts.Count()).Skip(1).FirstOrDefault();

            double AvarageAge() => users.Average(u => u.Age);

            List<User> OlderThen21() => users.Where(u => u.Age > 21).ToList();

            List<User> HaventPosts() => users.Where(u => u.Posts == null).ToList();

            List<User> UsersConteinWordInComment(string badWord) => users.Where(u => u.Posts.Where(c => c.Coments.Where(t => t.TextComment.Contains(badWord)) != null) != null).ToList();

            Dictionary<string, List<User>> BlockListMans(List<string> blockListWords)
            {
                Dictionary<string, List<User>> result = new Dictionary<string, List<User>>();
                foreach(string badWord in blockListWords)
                {
                    result[badWord] = UsersConteinWordInComment(badWord);
                }
                return result;
            }
        }
    }
}
