using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Domain;
using Domain.Attributes;
using Domain.Contracts;
using MongoDB.Driver;

namespace DataAccess
{
    public class MongoDbRepository<T> : IMongoDbRepository<T> where T : Document
    {
        private readonly IMongoCollection<T> collection;
        
        public MongoDbRepository(MongoDbSettings settings)
        {
            var database = new MongoClient(settings.ConnectionString).GetDatabase(settings.DatabaseName);
            collection = database.GetCollection<T>(GetCollectionName(typeof(T)));
        }
        
        protected string GetCollectionName(Type documentType)
        {
            return ((BsonCollectionAttribute) documentType.GetCustomAttributes(
                    typeof(BsonCollectionAttribute),
                    true)
                .FirstOrDefault())?.CollectionName;
        }

        public IQueryable<T> AsQueryable()
        {
            return collection.AsQueryable();
        }

        public async Task<IEnumerable<T>> FilterBy(Expression<Func<T, bool>> filterExpression)
        {
            return await collection.Find(filterExpression).ToListAsync();
        }

        public async Task Insert(T document)
        {
            await collection.InsertOneAsync(document);
        }

        public async Task Insert(ICollection<T> documents)
        {
            await collection.InsertManyAsync(documents);
        }

        public async Task Update(T document)
        {
            var filter = Builders<T>.Filter.Eq(doc => doc.Id, document.Id);
            await collection.FindOneAndReplaceAsync(filter, document);
        }

        public async Task Delete(Expression<Func<T, bool>> filterExpression)
        {
            await collection.FindOneAndDeleteAsync(filterExpression);
        }
    }
}