using Microsoft.WindowsAzure.ServiceRuntime;
using MongoDB.Driver;
using MongoDB.Driver.Builders;
using MongoRepository;
using System.Configuration;

namespace ScribemaniaAPI.Collections
{
    public abstract class Collection<T> : MongoRepository<T> where T : Entity
    {
        public Collection() : base(GetConnectionString()) { }

        /// <summary>
        /// Retrieves connection string using Azure service configuration or default of config file.
        /// </summary>
        /// <returns></returns>
        private static string GetConnectionString()
        {
            var connectionStringName = "MongoServerSettings";

            string mongoConnectionString = "";

            try
            {
                mongoConnectionString = RoleEnvironment.GetConfigurationSettingValue(connectionStringName);
            }
            catch (RoleEnvironmentException)
            {
                mongoConnectionString = ConfigurationManager.ConnectionStrings[connectionStringName].ConnectionString;
            }

            return mongoConnectionString;
        }

        protected T FindAndModifyById(string id, IMongoUpdate update)
        {
            var query = Query<T>.EQ(item => item.Id, id);

            var result = this.collection.FindAndModify(new FindAndModifyArgs
            {
                Query = query,
                Update = update
            });

            return result.GetModifiedDocumentAs<T>();
        }
    }
}
