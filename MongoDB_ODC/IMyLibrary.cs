using OutSystems.ExternalLibraries.SDK;
using System.Collections.Generic;

namespace MongoDB_ODC
{
    [OSInterface]
    public interface IMongoDB
    {
        bool ValidateConnection(string connectionString, string databaseName);
        List<string> GetCollectionDocuments(string collectionName, string connectionString, string databaseName);
        List<string> GetPaginatedDocuments(string collectionName, int skip, int limit);

    }
}