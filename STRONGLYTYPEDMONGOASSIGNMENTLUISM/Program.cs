using System;
using MongoDB.Bson;
using MongoDB.Driver;

namespace STRONGLYTYPEDMONGOASSIGNMENTLUISM
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string uri = "mongodb://localhost:27017/";
            var client = new MongoClient(uri);

        
            var myDB = client.GetDatabase("PeopleMT");

            
            var collection = myDB.GetCollection<PersonInfo>("Persons");

     
            var person1 = new PersonInfo { Last_Name = "Martinez", Age = 30, City = "Chicago" };
            var person2 = new PersonInfo { Last_Name = "Gray", Age = 20, City = "Atlanta" };
            var person3 = new PersonInfo { Last_Name = "Rodriguez", Age = 60, City = "Los Angeles" };

            
            collection.InsertMany(new[] { person1, person2, person3 });

            Console.WriteLine("Inserted three people\n");

           
            var firstPerson = collection.Find(new BsonDocument()).FirstOrDefault();
            Console.WriteLine($"First Person: {firstPerson.Last_Name}, Age: {firstPerson.Age}, City: {firstPerson.City}\n");

           
            var filter40 = Builders<PersonInfo>.Filter.Gte(p => p.Age, 40);
            var over40 = collection.Find(filter40).ToList();

            Console.WriteLine("People Over 40");
            foreach (var p in over40)
            {
                Console.WriteLine($"{p.Last_Name}, Age: {p.Age}, City: {p.City}");
            }
            Console.WriteLine();

      
            var updateAdd10 = Builders<PersonInfo>.Update.Inc(p => p.Age, 10);
            collection.UpdateMany(filter40, updateAdd10);
            Console.WriteLine("People over 40 just got 10 years older!!!!!!\n");

          
            var Filter50 = Builders<PersonInfo>.Filter.Gte(p => p.Age, 50);
            var over50 = collection.Find(Filter50).ToList();
            Console.WriteLine("People over 50");
            foreach (var p in over50)
            {
                Console.WriteLine($"{p.Last_Name}, Age: {p.Age}, City: {p.City}");
            }
            Console.WriteLine();

      
            var newPerson = new PersonInfo
            {
                Id = firstPerson.Id, 
                Last_Name = "Zepeda",
                Age = 37,
                City = "New York"
            };

            collection.ReplaceOne(p => p.Id == firstPerson.Id, newPerson);

        
            var replaced = collection.Find(p => p.Id == firstPerson.Id).FirstOrDefault();
            Console.WriteLine("Document was replaced");
            Console.WriteLine($"{replaced.Last_Name}, Age: {replaced.Age}, City: {replaced.City}");

            Console.WriteLine("\n Press any key to exit.");
            Console.ReadKey();
        }
    }
}