using MongoDB.Driver;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;


namespace STRONGLYTYPEDMONGOASSIGNMENTLUISM
{
    public class PersonInfo
    {

        [BsonId] 
        public ObjectId Id { get; set; }

        public string Last_Name { get; set; }
        public int Age { get; set; }
        public string City { get; set; }


    }
}
