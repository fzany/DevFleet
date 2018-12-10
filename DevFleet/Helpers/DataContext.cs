using DevFleet.Models;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFleet.Helpers
{
    public class DataContext
    {
        public MongoDatabase Database;
        public DataContext()
        {
            string connectionString = @"mongodb://devtest:ws8CGV6bEc2WLDT@azurecluster-shard-00-00-j6ddx.azure.mongodb.net:27017,azurecluster-shard-00-01-j6ddx.azure.mongodb.net:27017,azurecluster-shard-00-02-j6ddx.azure.mongodb.net:27017/test?ssl=true&replicaSet=AzureCluster-shard-0&authSource=admin&retryWrites=true";
            MongoClientSettings settings = MongoClientSettings.FromUrl(new MongoUrl(connectionString));
            MongoClient client = new MongoClient(settings);
            MongoServer server = client.GetServer();
            Database = server.GetDatabase("azurecluster");
        }

        public MongoCollection<Fleet> Fleet => Database.GetCollection<Fleet>(typeof(Fleet).Name.ToLower());
    }
}
