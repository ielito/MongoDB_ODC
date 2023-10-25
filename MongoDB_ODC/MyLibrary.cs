using MongoDB.Bson;
using MongoDB.Driver;
using System.Collections.Generic;

namespace MongoDB_ODC
{
    public class MyLibrary : IMongoDB
    {
        private MongoService _mongoService;

        public MyLibrary()
        {

        }

        public MyLibrary(string connectionString, string databaseName)
        {
            _mongoService = new MongoService(connectionString, databaseName);
        }

        public bool ValidateConnection(string connectionString, string databaseName)
        {
            _mongoService = new MongoService(connectionString, databaseName);

            return _mongoService.ValidateConnection();
        }

        public List<string> GetCollectionDocuments(string collectionName)
        {

            if (_mongoService == null)
            {
                throw new InvalidOperationException("MongoService has not been initialized. Call ValidateConnection first.");
            }

            var collection = _mongoService.GetCollection(collectionName);
            var bsonList = collection.Find(new BsonDocument()).ToList();

            var jsonList = new List<string>();
            foreach (var bson in bsonList)
            {
                jsonList.Add(bson.ToJson());
            }

            return jsonList;
        }

        public List<string> GetPaginatedDocuments(string collectionName, int skip, int limit)
        {
            if (_mongoService == null)
            {
                throw new InvalidOperationException("MongoService has not been initialized. Call ValidateConnection first.");
            }

            var collection = _mongoService.GetCollection(collectionName);
            var documents = collection.Find(new BsonDocument()).Skip(skip).Limit(limit).ToList();

            var jsonList = new List<string>();
            foreach (var doc in documents)
            {
                jsonList.Add(doc.ToJson());
            }

            return jsonList;
        }
    }
}
