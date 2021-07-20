using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeetCodeTasks
{
    public class User
    {
        public User()
        {
            Posts = new List<Post>();
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public List<Post> Posts { get; set; }
    }

    public class Post
    {
        public Post()
        {
            Coments = new List<Comment>();
        }
        public string Header { get; set; }
        public string TextPost { get; set; }
        public User User { get; set; }
        public List<Comment> Coments { get; set; }
    }

    public class Comment
    {
        public User User { get; set; }
        public string TextComment { get; set; }
    }
}
