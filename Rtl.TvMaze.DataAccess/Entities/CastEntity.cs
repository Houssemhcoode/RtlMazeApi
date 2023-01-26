using System;
using System.Runtime.Serialization;
using MongoDB.Bson.Serialization.Attributes;

namespace Rtl.TvMaze.DataAccess.Entities
{
    [BsonIgnoreExtraElements]
    public class CastEntity
    {
        [DataMember, BsonElement("id")]
        public int Id { get; set; }

        [DataMember, BsonElement("name")]
        public string Name { get; set; }

        [DataMember, BsonElement("birthday")]
        public DateTime Birthday { get; set; }
    }
}
