using OutSystems.ExternalLibraries.SDK;
using System.Collections.Generic;

namespace MongoDB_ODC
{
    [OSInterface(Name = "MongoDB")]
    public interface IMongoDB
    {
        bool ValidateConnection(string connectionString, string databaseName);
        List<string> GetCollectionDocuments(string collectionName, string connectionString, string databaseName);
    }
}