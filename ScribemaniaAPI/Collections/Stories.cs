using MongoDB.Driver.Builders;
using ScribemaniaAPI.Models;
using System;
using UnicodeSlug;

namespace ScribemaniaAPI.Collections
{
    public class Stories : Collection<Story>, IStories
    {
        /// <summary>
        /// Adds a story.
        /// </summary>
        /// <param name="story"></param>
        /// <returns>The added Story.</returns>
        public override Story Add(Story story)
        {
            if (String.IsNullOrEmpty(story.Slug))
            {
                var slugOptions = new SlugOptions();
                story.Slug = slugOptions.GenerateSlug(story.Title);
            }

            var result = this.collection.Insert(story);

            // check for duplicate key error - unique index constraint on slug has been violated
            // append a random number and try again
            if (result.Code == 11000)
            {
                story.Slug += "-" + new Random().Next(1, 10);
                return Add(story);
            }
            else
            {
                return story;
            }
        }

        /// <summary>
        /// Adds a paragraph to a story.
        /// </summary>
        /// <param name="storyId"></param>
        /// <param name="paragraph"></param>
        /// <returns>The updated story, null if not found.</returns>
        public Story AddParagraph(string storyId, Paragraph paragraph)
        {
            var update = Update<Story>.Push(story => story.Paragraphs, paragraph);
            return FindAndModifyById(storyId, update);
        }

        /// <summary>
        /// Increments the number of favorites the story has received and adds the associated user id.
        /// </summary>
        /// <param name="storyId"></param>
        /// <param name="userId"></param>
        /// <returns>The updated story, null if not found.</returns>
        public Story AddFavorite(string storyId, string userId)
        {
            var updateUsers = Update<Story>.AddToSet(story => story.StarredBy, userId);
            return FindAndModifyById(storyId, updateUsers);
        }

        /// <summary>
        /// Decrements the number of favorites the story has received and removes the associated user id.
        /// </summary>
        /// <param name="storyId"></param>
        /// <param name="userId"></param>
        /// <returns>The updated story, null if not found.</returns>
        public Story RemoveFavorite(string storyId, string userId)
        {
            var updateUsers = Update<Story>.Pull(story => story.StarredBy, userId);
            return FindAndModifyById(storyId, updateUsers);
        }
    }
}