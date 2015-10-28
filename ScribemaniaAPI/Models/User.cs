using MongoRepository;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace ScribemaniaAPI.Models
{
    [JsonObject(MemberSerialization.OptOut)]
    public class User : Entity
    {
        public User()
        {
            GroupIds = Enumerable.Empty<string>();
            StarredStoryIds = Enumerable.Empty<string>();
        }

        public string Provider { get; set; }
        public string ProviderId { get; set; }
        public Uri ProviderProfile { get; set; }
        public Uri ProviderPicture { get; set; }
        [EmailAddress]
        public string Email { get; set; }
        public Gender Gender { get; set; }
        public string Location { get; set; }
        public string Locale { get; set; }
        public string DisplayName { get; set; }
        public IEnumerable<string> GroupIds { get; set; }
        public IEnumerable<string> StarredStoryIds { get; set; }
    }

    public enum Gender
    {
        Unknown,
        Male,
        Female
    }
}