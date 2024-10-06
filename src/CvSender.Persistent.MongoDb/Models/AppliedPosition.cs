using CvSender.Core.Interfaces;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;

namespace CvSender.Persistent.MongoDb.Models
{
        internal class AppliedPosition : IAppliedPosition
        {
                [BsonId]
                [BsonRepresentation(BsonType.ObjectId)]
                public string? Id { get; set; }

                public string? Company { get; set; }

                public required string Position { get; set; }

                public string? ContactPerson { get; set; }

                public DateTime CreatedUtc { get; set; }
        }
}
