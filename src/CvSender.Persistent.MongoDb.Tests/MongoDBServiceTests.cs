//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using CvSender.Persistent.MongoDb.Models;
//using CvSender.Persistent.MongoDb.Repository;
//using Xunit;

//namespace CvSender.Persistent.MongoDb.Tests
//{
//        public class MongoDBServiceTests
//        {
//                private readonly MongoDBService<AppliedPosition> _mongoDBService;
//                private readonly string _connectionString = "";
//                private readonly string _databaseName = "CvSender";
//                private readonly string _collectionName = "AppliedPositions";

//                public MongoDBServiceTests()
//                {
//                        _mongoDBService = new MongoDBService<AppliedPosition>(_connectionString, _databaseName, _collectionName);
//                }

//                [Fact]
//                public async Task AddAsync_Should_Add_New_Entity()
//                {
//                        var entity = new AppliedPosition { Company = "TestEntity", Position = "TestPosition" };

//                        await _mongoDBService.AddAsync(entity);
//                }

//                [Fact]
//                public async Task GetAllAsync_Should_Return_All_Entities()
//                {
//                        var entities = await _mongoDBService.GetAllAsync();

//                        Assert.True(entities != null);
//                }

//                //[Fact]
//                //public async Task GetAllAsync_Should_Return_All_Entities()
//                //{
//                //        // Arrange
//                //        var entity1 = new TestEntity { Name = "Entity1" };
//                //        var entity2 = new TestEntity { Name = "Entity2" };

//                //        await _mongoDBService.AddAsync(entity1);
//                //        await _mongoDBService.AddAsync(entity2);

//                //        // Act
//                //        var entities = await _mongoDBService.GetAllAsync();

//                //        // Assert
//                //        entities.Should().HaveCountGreaterThanOrEqualTo(2);
//                //}

//                //[Fact]
//                //public async Task GetByIdAsync_Should_Return_Entity_By_Id()
//                //{
//                //        // Arrange
//                //        var entity = new TestEntity { Name = "FindByIdEntity" };
//                //        await _mongoDBService.AddAsync(entity);

//                //        // Act
//                //        var foundEntity = await _mongoDBService.GetByIdAsync(entity.Id.ToString());

//                //        // Assert
//                //        foundEntity.Should().NotBeNull();
//                //        foundEntity.Name.Should().Be("FindByIdEntity");
//                //}

//                //[Fact]
//                //public async Task UpdateAsync_Should_Update_Entity()
//                //{
//                //        // Arrange
//                //        var entity = new TestEntity { Name = "OriginalEntity" };
//                //        await _mongoDBService.AddAsync(entity);

//                //        var updatedEntity = new TestEntity { Id = entity.Id, Name = "UpdatedEntity" };

//                //        // Act
//                //        await _mongoDBService.UpdateAsync(entity.Id.ToString(), updatedEntity);
//                //        var foundEntity = await _mongoDBService.GetByIdAsync(entity.Id.ToString());

//                //        // Assert
//                //        foundEntity.Should().NotBeNull();
//                //        foundEntity.Name.Should().Be("UpdatedEntity");
//                //}

//                //[Fact]
//                //public async Task DeleteAsync_Should_Remove_Entity_By_Id()
//                //{
//                //        // Arrange
//                //        var entity = new TestEntity { Name = "DeleteEntity" };
//                //        await _mongoDBService.AddAsync(entity);

//                //        // Act
//                //        await _mongoDBService.DeleteAsync(entity.Id.ToString());
//                //        var foundEntity = await _mongoDBService.GetByIdAsync(entity.Id.ToString());

//                //        // Assert
//                //        foundEntity.Should().BeNull();
//                //}

//                //// Cleanup after tests to keep the database clean
//                //public async Task DisposeAsync()
//                //{
//                //        // Clean up the test collection
//                //        await _mongoDBService.DeleteAsync(Builders<TestEntity>.Filter.Empty.ToString());
//                //}
//        }
//}
