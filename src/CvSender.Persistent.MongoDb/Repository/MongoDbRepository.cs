using CvSender.Core.Interfaces;
using MongoDB.Bson;
using MongoDB.Driver;

namespace CvSender.Persistent.MongoDb.Repository
{
        public class MongoDBService<T> : IRepository<T>
        {
                private readonly IMongoCollection<T> _collection;

                public MongoDBService(string connectionString, string databaseName, string collectionName)
                {
                        var client = new MongoClient(connectionString);
                        var database = client.GetDatabase(databaseName);
                        _collection = database.GetCollection<T>(collectionName);
                }

                public async Task<List<T>> GetAllAsync()
                {
                        return await _collection.Find(_ => true).ToListAsync();
                }

                public async Task<T> GetByIdAsync(string id)
                {
                        var filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
                        return await _collection.Find(filter).FirstOrDefaultAsync();
                }

                public async Task AddAsync(T entity)
                {
                        await _collection.InsertOneAsync(entity);
                }

                public async Task UpdateAsync(string id, T entity)
                {
                        var filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
                        await _collection.ReplaceOneAsync(filter, entity);
                }

                public async Task DeleteAsync(string id)
                {
                        var filter = Builders<T>.Filter.Eq("_id", new ObjectId(id));
                        await _collection.DeleteOneAsync(filter);
                }
        }
}
