using MongoRepository;
using ScribemaniaAPI.Models;

namespace ScribemaniaAPI.Collections
{
    public interface IUsers : IRepository<User>
    {
        Story FavoriteStory(string userId, string storyId);

        Story UnfavoriteStory(string userId, string storyId);
    }
}
