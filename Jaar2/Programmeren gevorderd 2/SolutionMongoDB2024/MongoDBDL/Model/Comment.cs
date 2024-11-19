using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBDL.Model
{
    public class Comment
    {
        public Comment(string author, string message, DateTime created, List<string> tags)
        {
            Author = author;
            Message = message;
            Created = created;
            Tags = tags;
        }

        public string Author { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
        public List<String> Tags { get; set; }
    }
}
