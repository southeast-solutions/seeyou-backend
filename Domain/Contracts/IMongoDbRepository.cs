using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;

namespace Domain.Contracts
{
    public interface IMongoDbRepository<T> where T : Document
    {
        IQueryable<T> AsQueryable();
        Task<T> FindById(ObjectId id);
        Task<IEnumerable<T>> FilterBy(Expression<Func<T, bool>> filterExpression);
        Task Insert(T document);
        Task Insert(ICollection<T> documents);
        Task Update(T document);
        Task Delete(Expression<Func<T, bool>> filterExpression);
    }
}