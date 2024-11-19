using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBDL.Model
{
    public class Post
    {
        public Post(string title, string author, string description, DateTime created, List<Comment> comments)
        {
            Title = title;
            Author = author;
            Description = description;
            Created = created;
            Comments = comments;
        }

        public Post(ObjectId id, string title, string author, string description, DateTime created, List<Comment> comments)
        {
            Id = id;
            Title = title;
            Author = author;
            Description = description;
            Created = created;
            Comments = comments;
        }

        public ObjectId Id { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public DateTime Created {  get; set; }
        public List<Comment> Comments { get; set; }
    }
}
