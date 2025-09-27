using CvSender.Persistent.MongoDb.Models;
using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CvSender.Core.Repository
{
        public class MongoDBService : IMongoDbService
        {
                private readonly IMongoCollection<AppliedPosition> _collection;

                public MongoDBService(/*string connectionString, string databaseName, string collectionName*/)
                {
                        //var client = new MongoClient(connectionString);
                        //var database = client.GetDatabase(databaseName);
                        //_collection = database.GetCollection<T>(collectionName);
                        var client = new MongoClient("");
                        var database = client.GetDatabase("CvSender");
                        _collection = database.GetCollection<AppliedPosition>("AppliedPositions");
                }

                public async Task<List<AppliedPosition>> GetAllAsync()
                {
                        var entities = await _collection.Find(_ => true).ToListAsync();

                        return entities;
                }

                public async Task<AppliedPosition> GetByIdAsync(string id)
                {
                        var filter = Builders<AppliedPosition>.Filter.Eq("_id", new ObjectId(id));
                        return await _collection.Find(filter).FirstOrDefaultAsync();
                }

                public async Task AddAsync(AppliedPosition entity)
                {
                        await _collection.InsertOneAsync(entity);
                }

                public async Task UpdateAsync(string id, AppliedPosition entity)
                {
                        var filter = Builders<AppliedPosition>.Filter.Eq("_id", new ObjectId(id));
                        await _collection.ReplaceOneAsync(filter, entity);
                }

                public async Task DeleteAsync(string id)
                {
                        var filter = Builders<AppliedPosition>.Filter.Eq("_id", new ObjectId(id));
                        await _collection.DeleteOneAsync(filter);
                }
        }

        public interface IMongoDbService
        {
                Task<List<AppliedPosition>> GetAllAsync();
                
                Task AddAsync(AppliedPosition entity);
        }
}
