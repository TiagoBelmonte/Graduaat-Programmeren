using MongoDB.Driver;
using MongoDBDL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MongoDBDL
{
    public class PostDAO
    {
        private IMongoClient client;
        private IMongoDatabase database;
        private IMongoCollection<Post> postsCollection;
        private string connectionString;

        public PostDAO(string connectionString)
        {
            this.connectionString = connectionString;
            client = new MongoClient(connectionString);
            database = client.GetDatabase("Posts");
            postsCollection = database.GetCollection<Post>("Post");
        }

        public void WritePost(Post post)
        {
            postsCollection.InsertOne(post);
        }

        public void WritePosts(List<Post> posts) 
        {
            postsCollection.InsertMany(posts);
        }

        public List<Post> FilterPostsByAuthor(string author)
        {
            var filter = Builders<Post>.Filter.Eq(x => x.Author, author);
            return postsCollection.Find(filter).ToList();
        }

        public List<Post> FindPostFromAuthor(string author)
        { 
            return postsCollection.Find(x => x.Author == author).ToList();
        }

        public List<Post> FindPostByAuthorAndDate(string author, DateTime startDate, DateTime endDate)
        { 
            var filterAuthor = Builders<Post>.Filter.Eq(x => x.Author, author);
            var filterDate = Builders<Post>.Filter.And(Builders<Post>.Filter.Gte(x => x.Created, startDate),
                                                       Builders<Post>.Filter.Lte(x => x.Created,endDate));
            return postsCollection.Find(filterAuthor&filterDate).ToList();
        }

        public List<Post> FindPostFromAuthorAndDate(string author, DateTime startDate, DateTime endDate)
        {
            return  postsCollection.Find(x => x.Author == author && x.Created >= startDate && x.Created <= endDate).ToList();
        }

        public List<Post> FindPostWithTag(string tag)
        {
            var filter = Builders<Post>.Filter.ElemMatch(
                p => p.Comments,
                c => c.Tags.Contains(tag));
            return postsCollection.Find(filter).ToList();
        }

        public List<Post> FindPostWithAnyTag(List<string> tags)
        {
            var filter = Builders<Post>.Filter.ElemMatch(
                p => p.Comments,
                c => c.Tags.Any(x =>tags.Contains(x)));
            return postsCollection.Find(filter).ToList();
        }

        public List<Post> FindPostWithAllTags(List<string> tags)
        {
            var filter = Builders<Post>.Filter.ElemMatch(
                p => p.Comments,
                c => c.Tags.Any(x => tags.Contains(x)));
            return postsCollection.Find(filter).ToList();
        }

        public void UpdateCompleteObject(Post post)
        { 
            var filter = Builders<Post>.Filter.Eq(x => x.Id, post.Id);
            postsCollection.ReplaceOne(filter, post);
        }
    }
}
