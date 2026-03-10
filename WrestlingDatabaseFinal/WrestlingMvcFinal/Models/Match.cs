using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace WrestlingMvcFinal.Models
{
    [BsonIgnoreExtraElements]
    public class Match
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Promotion")]
        public string Company { get; set; } = string.Empty;

        public string Winner { get; set; } = string.Empty;
        public string Loser { get; set; } = string.Empty;

        [BsonElement("Championship")]
        public string Championship { get; set; } = string.Empty;

        [BsonElement("PPV")]
        public string PpvString { get; set; } = string.Empty;

        public bool PayPerView => PpvString.ToLower() == "yes";
        public bool ChampionshipOnLine => Championship != "NA";

        [BsonElement("Event")]
        public string Event { get; set; } = string.Empty;

        [BsonElement("Date")]
        public string DateString { get; set; } = string.Empty;

      
    }
}
