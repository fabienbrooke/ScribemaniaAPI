using MongoRepository;
using ScribemaniaAPI.Models;

namespace ScribemaniaAPI
{
    public static class Indexes
    {
        public static void Register()
        {
            var stories = new MongoRepositoryManager<Story>();
            stories.EnsureIndex("Slug");
            stories.EnsureIndex("Genre");
            stories.EnsureIndex("GroupId");
            stories.EnsureIndex("CreatedDate");
            stories.EnsureIndex("CreatorId");

            var groups = new MongoRepositoryManager<Group>();
            groups.EnsureIndex("Slug");
            groups.EnsureIndex("CreatedDate");
            groups.EnsureIndex("CreatorId");

            var users = new MongoRepositoryManager<User>();
            users.EnsureIndex("DisplayName");
        }
    }
}