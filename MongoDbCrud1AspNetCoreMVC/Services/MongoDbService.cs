using MongoDB.Driver;
using MongoDbCrud1AspNetCoreMVC.Models;

namespace MongoDbCrud1AspNetCoreMVC.Services
{
    public class MongoDbService
    {
        private readonly IMongoCollection<Person> _collection;

        public MongoDbService(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["ConnectionStrings:DefaultConnection"]);
            var database = client.GetDatabase("PersonDB1");
            _collection = database.GetCollection<Person>("Persons");
        }

        public async Task<List<Person>> GetAll()
        {
            return await _collection.Find(_ => true).ToListAsync();
        }

        public async Task<Person> GetById(string id)
        {
            return await _collection.Find(person => person.PersonId == id).FirstOrDefaultAsync();
        }

        public async Task Create(Person person)
        {
            await _collection.InsertOneAsync(person);
        }

        public async Task Update(string id, Person person)
        {
            await _collection.ReplaceOneAsync(p => p.PersonId == id, person);
        }

        public async Task Delete(string id)
        {
            await _collection.DeleteOneAsync(p => p.PersonId == id);
        }
    }
}
