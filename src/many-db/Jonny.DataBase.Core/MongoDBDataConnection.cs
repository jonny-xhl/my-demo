using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Jonny.DataBase.Core
{
    public partial class MongoDBDataConnection : DataConnectionBase
    {
        public static string dbName = "";

        public override string ConnectionString
        {
            get;
            set;
        } = "mongodb://root:123456@localhost:27017";

        public override string GetConnectionStringWithLoginInfo(string userName, string password)
        {
            MongoUrlBuilder builder = new MongoUrlBuilder(ConnectionString);
            builder.Username = userName;
            builder.Password = password;
            builder.DatabaseName = "Test";
            builder.AuthenticationMechanism = "admin";
            builder.ReadPreference = new ReadPreference(ReadPreferenceMode.Primary);
            builder.ApplicationName = "MongoDB Compass";
            builder.AllowInsecureTls = false;
            builder.UseTls = false;

            return builder.ToString();
        }

        public override string[] GetTableNames()
        {
            List<string> list = new List<string>();

            MongoClient client = new MongoClient(ConnectionString);
            IMongoDatabase db = client.GetDatabase(dbName);
            IAsyncCursor<BsonDocument> collections = db.ListCollections();
            foreach (var item in collections.ToList())
            {
                list.Add(item[0].ToString());
            }
            return list.ToArray();
        }
    }
}
