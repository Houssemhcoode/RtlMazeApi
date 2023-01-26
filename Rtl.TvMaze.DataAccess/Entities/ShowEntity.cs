using System.Collections.Generic;
using System.Runtime.Serialization;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Rtl.TvMaze.DataAccess.Entities
{
    [BsonIgnoreExtraElements]
    public class ShowEntity
    {
        [BsonId]
        [DataMember, BsonElement("internalId")]
        public ObjectId InternalId { get; set; }

        [DataMember, BsonElement("id")]
        public int Id { get; set; }

        [DataMember, BsonElement("name")]
        public string Name { get; set; }

        [DataMember, BsonElement("cast")]
        public IEnumerable<CastEntity> Cast { get; set; }
    }
}
