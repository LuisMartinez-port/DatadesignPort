using System;
using System.Collections.Generic;
using MongoDB.Bson;
using MongoDB.Driver;

namespace DYNAMICMONGO
{
    class Program
    {
        static void Main(string[] args)
        {
  
            var client = new MongoClient("mongodb://localhost:27017");
            var database = client.GetDatabase("LuisNames");
            var collection = database.GetCollection<BsonDocument>("names");

            InsertIfNotExists(collection, "smith", 30);
            InsertIfNotExists(collection, "jones", 40);
            InsertIfNotExists(collection, "Gray", 25);
            InsertIfNotExists(collection, "Martinez", 50);

            Console.WriteLine("Initial records inserted (duplicates prevented).\n");

            var smith = collection.Find(Builders<BsonDocument>.Filter.Eq("last_name", "smith")).FirstOrDefault();
            var jones = collection.Find(Builders<BsonDocument>.Filter.Eq("last_name", "jones")).FirstOrDefault();

            Console.WriteLine("Specific Records:");
            Console.WriteLine($"Smith: {smith}");
            Console.WriteLine($"Jones: {jones}\n");


            Console.WriteLine("All Records:");
            var cursor = collection.Find(new BsonDocument()).ToCursor();
            foreach (var doc in cursor.ToEnumerable())
            {
                Console.WriteLine(doc);
            }
            Console.WriteLine();


            var FilterForSmith = Builders<BsonDocument>.Filter.Eq("last_name", "smith");
            var updateCity = Builders<BsonDocument>.Update.Set("city", "Chicago");
            collection.UpdateOne(FilterForSmith, updateCity);
            Console.WriteLine("Updated Smith with city = Chicago\n");


            var filterMartinez = Builders<BsonDocument>.Filter.Eq("last_name", "Martinez");
            var updateMartinezCity = Builders<BsonDocument>.Update.Set("city", "Chicago");
            collection.UpdateOne(filterMartinez, updateMartinezCity);
            Console.WriteLine("Updated Martinez with city = Chicago\n");


            var filterZip = Builders<BsonDocument>.Filter.And(
                Builders<BsonDocument>.Filter.Gt("age", 30),
                Builders<BsonDocument>.Filter.Eq("city", "Chicago")
            );
            var updateZip = Builders<BsonDocument>.Update.Set("zipcode", 60601);
            collection.UpdateMany(filterZip, updateZip);
            Console.WriteLine("Updated records with zipcode 60601\n");

            Console.WriteLine("Records that have a zipcode of 60601:");
            cursor = collection.Find(Builders<BsonDocument>.Filter.Eq("zipcode", 60601)).ToCursor();
            foreach (var doc in cursor.ToEnumerable())
            {
                Console.WriteLine(doc);
            }
            Console.WriteLine();

   
            var filterHobby = Builders<BsonDocument>.Filter.Or(
                Builders<BsonDocument>.Filter.Eq("last_name", "smith"),
                Builders<BsonDocument>.Filter.Gt("age", 35)
            );
            var ChangeHobby = Builders<BsonDocument>.Update.Set("favorite_artist", "FUZIGISH")
                                                           .Set("hobby", "Music");
            collection.UpdateMany(filterHobby, ChangeHobby);
            Console.WriteLine("Updated records with favorite_artist = FUZIGISH and hobby = Music\n");


            Console.WriteLine("All Records After Updates:");
            cursor = collection.Find(new BsonDocument()).ToCursor();
            foreach (var doc in cursor.ToEnumerable())
            {
                Console.WriteLine(doc);
            }

            Console.WriteLine("\nProgram complete. Press any key to exit.");
            Console.ReadKey();
        }


        static void InsertIfNotExists(IMongoCollection<BsonDocument> collection, string lastName, int age)
        {
            var exists = collection.Find(Builders<BsonDocument>.Filter.Eq("last_name", lastName)).Any();
            if (!exists)
            {
                var doc = new BsonDocument
                {
                    { "last_name", lastName },
                    { "age", age }
                };
                collection.InsertOne(doc);
            }
        }
    }
}
