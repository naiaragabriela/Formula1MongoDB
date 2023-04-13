using System.Data;
using Formula1MongoDB;
using MongoDB.Bson;
using MongoDB.Bson.Serialization;
using MongoDB.Driver;

internal class Program
{
    private static void Main(string[] args)
    {
        MongoClient mongo = new MongoClient("mongodb://localhost:27017");


        var baseDeDados = mongo.GetDatabase("Formula1");
        var collection = baseDeDados.GetCollection<BsonDocument>("Pilotos");
        var documents = collection.Find(new BsonDocument()).ToList();
        #region CRUD
        //Console.WriteLine("Informe o nome do piloto: ");
        //string n = Console.ReadLine();

        //var filter = Builders<BsonDocument>.Filter.Regex("Driver", n);

        //var find_drive = collection.Find(filter).FirstOrDefault();

        //var driver = BsonSerializer.Deserialize<Driver>(find_drive);


        //Console.WriteLine(driver.ToString());


        //Console.WriteLine("Nome: ");
        //string n = Console.ReadLine();

        //Console.WriteLine("Abreviação: ");
        //string a = Console.ReadLine();

        //Console.WriteLine("Numero: ");
        //int m = int.Parse(Console.ReadLine());

        //Console.WriteLine("Equipe: ");
        //string t = Console.ReadLine();

        //Console.WriteLine("País: ");
        //string p = Console.ReadLine();

        //Console.WriteLine("Data de Nascimento: ");
        //string d = Console.ReadLine();


        //Driver driver = new(n, a, m, t, p, d);
        //Console.WriteLine(driver.ToString());

        //var dr = new BsonDocument
        //{
        //    { "Driver", driver.Name },
        //    { "Abbreviation", driver.Abbreviation },
        //    { "No", driver.Number },
        //    { "Team", driver.Team },
        //    { "Country", driver.Country },
        //    { "Date of Birth", driver.BirthDate }
        //};
        //Console.WriteLine(dr);

        //collection.InsertOne(dr);
        #endregion

        Console.WriteLine("Informe o nome do Piloto");
        string n = Console.ReadLine();

        var pilot = collection.Find(Builders<BsonDocument>.Filter.Regex("Driver", n)).First();

        //var driverPilot = BsonSerializer.Deserialize<Driver>(pilot);
        Console.WriteLine("Informe um novo número para atualizar: ");
        int number = int.Parse(Console.ReadLine());

        // collection.UpdateOne(Builders<BsonDocument>.Filter.Regex("Driver", n), 
        //  Builders<BsonDocument>.Update.Set("No",number));

        var filter = Builders<BsonDocument>.Filter.Regex("Driver", n);
        var update = Builders<BsonDocument>.Update.Set("No", number);

        collection.FindOneAndDelete(filter);
        collection.DeleteOne(filter);

    }
}
