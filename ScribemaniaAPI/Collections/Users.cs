using MongoDB.Driver.Builders;
using ScribemaniaAPI.Models;

namespace ScribemaniaAPI.Collections
{
    public class Users : Collection<User>, IUsers
    {
        private IStories stories;


        public Users(IStories repository)
        {
            stories = repository;
        }

        public Users()
        {
            stories = new Stories();
        }


        public Story FavoriteStory(string userId, string storyId)
        {
            var updateUserFavorites = Update<User>.AddToSet(user => user.StarredStoryIds, storyId);
            var updatedUser = FindAndModifyById(userId, updateUserFavorites);

            if (updatedUser != null)
            {
                var story = stories.AddFavorite(storyId, userId);

                if (story == null)
                {
                    // update to story failed, undo update to user
                    updateUserFavorites = Update<User>.Pull(user => user.StarredStoryIds, storyId);
                    updatedUser = FindAndModifyById(userId, updateUserFavorites);
                }

                return story;
            }
            else
            {
                return null;
            }
        }

        public Story UnfavoriteStory(string userId, string storyId)
        {
            var updateUserFavorites = Update<User>.Pull(user => user.StarredStoryIds, storyId);
            var updatedUser = FindAndModifyById(userId, updateUserFavorites);

            if (updatedUser != null)
            {
                var story = stories.RemoveFavorite(storyId, userId);

                if (story == null)
                {
                    // update to story failed, undo update to user
                    updateUserFavorites = Update<User>.AddToSet(user => user.StarredStoryIds, storyId);
                    updatedUser = FindAndModifyById(userId, updateUserFavorites);
                }

                return story;
            }
            else
            {
                return null;
            }
        }
    }
}