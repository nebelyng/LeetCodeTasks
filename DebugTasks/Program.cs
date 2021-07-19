using System;
using LeetCodeTasks;
using System.Linq;

namespace DebugTasks
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            User[] users = Init();

            var sortedUser = users.OrderByDescending(u => u.Posts.Count());
            var preLast = sortedUser.Skip(1).First();
            double avarageAge = users.Average(u => u.Age);
            var olderThen21 = users.Where(u => u.Age > 21);
            var haventPosts = users.Where(u => u.Posts == null);

            //найти у кого больше постов среди юзеров 2
            //второй снизу по количесту постов 1 done
            //средний возраст юзера 1 done
            //найти всех юзеров которым больше чем 21 1 done
            //найти всех юзеров у которых нет постов 2 done
            //найти юзера у которого в коментариях слово блять 3
            //найти юзереров и все коментарии юзеров у которых есть слово блять 4

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

        }
    }
}
