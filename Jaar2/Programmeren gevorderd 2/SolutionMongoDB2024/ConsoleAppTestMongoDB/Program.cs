using MongoDBDL;
using MongoDBDL.Model;

namespace ConsoleAppTestMongoDB

{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");
            string connectionString = @"mongodb://localhost:27017";
            List<Comment> comments = new List<Comment>()
            {
                new Comment("luc","top",new DateTime(2024,8,11), new List<String>(){"Hogent","NoSQL" }),
                 new Comment("Pol","great tutorial",new DateTime(2024,7,11), new List<String>(){"IT","NoSQL","c#" }),
                  new Comment("inga","fun",new DateTime(2024,8,11), new List<String>(){"Fun","NoSQL" })
            };
            Post post1 = new Post("MongoDB tutorial", "jos", "Learn about MonogDB document store", new DateTime(2024, 5, 11), comments);
            comments = new List<Comment>()
            {
                 new Comment("luc","top",new DateTime(2024,8,11), new List<String>(){"Hogent","NoSQL" }),
                 new Comment("Pol","great tutorial",new DateTime(2024,7,11), new List<String>(){"IT","NoSQL","c#" }),
                  new Comment("inga","fun",new DateTime(2024,8,11), new List<String>(){"Fun","REST" })
            };
            Post post2 = new Post("Asp.NET tutorial", "jos", "Learn to build a rest service", new DateTime(2024, 7, 11), comments);
            
            PostDAO dao = new PostDAO(connectionString);
            //dao.WritePosts(new List<Post>() { post1, post2 });
            //var p = dao.FilterPostsByAuthor("jos");
            //var p2 = dao.FindPostFromAuthor("jos");
            var x = dao.FindPostByAuthorAndDate("jos", new DateTime(2024, 2, 10), DateTime.Now);
            //var p4 = dao.FindPostFromAuthorAndDate("jos", new DateTime(2024,2,12), DateTime.Now);
            //var p5 = dao.FindPostWithTag("REST");
            //var p6 = dao.FindPostWithAnyTag(new List<string>() { "Fun", "NOSQL" });
            //var p7 = dao.FindPostWithAllTags(new List<string>() { "Fun", "NOSQL" });
            var post = x.First();
            post.Author = "Adolf";
            post.Comments.Add(new Comment("Stalin", "Koud brr", new DateTime(2024, 9, 20), new List<string>()
            { "Russia,Germany,NotFun"}
                ));
            dao.UpdateCompleteObject(post);
        }

    }
}
