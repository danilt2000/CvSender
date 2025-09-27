using CvSender.Core.Interfaces;
using CvSender.Persistent.MongoDb.Models;
using CvSender.Persistent.MongoDb.Repository;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace CvSender.Persistent.MongoDb
{
        public static class ServiceBindings
        {
                public static IServiceCollection AddPersistentMongoDb(this IServiceCollection serviceCollection, IConfiguration configuration)
                {
                        //serviceCollection.AddSingleton<IRepository<IAppliedPosition>>(provider =>
                        //{
                        //        var connectionString = configuration["MongoDbConnectionString"];
                        //        var databaseName = "CvSender";
                        //        var collectionName = "AppliedPositions";

                        //        return new MongoDBService<IAppliedPosition>(connectionString, databaseName, collectionName);
                        //});


                        //serviceCollection.AddSingleton<IRepository,>();
                        //serviceCollection.AddSingleton<IRepository<IAppliedPosition>, MongoDBService<IAppliedPosition>>();
                        //serviceCollection.AddSingleton<IRepository<IAppliedPosition>, MongoDBService<IAppliedPosition>>();
                        
                        return serviceCollection;
                }
        }
}
