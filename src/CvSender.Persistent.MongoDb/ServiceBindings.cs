using CvSender.Core.Interfaces;
using CvSender.Persistent.MongoDb.Models;
using CvSender.Persistent.MongoDb.Repository;
using Microsoft.Extensions.DependencyInjection;

namespace CvSender.Persistent.MongoDb
{
        public static class ServiceBindings
        {
                public static IServiceCollection AddPersistentMongoDb(this IServiceCollection serviceCollection/*, IConfiguration configuration*/)
                {
                        serviceCollection.AddSingleton<IRepository<IAppliedPosition>>(provider =>
                        {
                                var connectionString = "mongodb+srv://jdjdj8034:0ZGD04wtwsCl6QXY@cvsender.sydow.mongodb.net/?retryWrites=true&w=majority&appName=CvSender";
                                var databaseName = "CvSender";
                                var collectionName = "AppliedPositions";

                                return new MongoDBService<IAppliedPosition>(connectionString, databaseName, collectionName);
                        });

                        return serviceCollection;
                }
        }
}
