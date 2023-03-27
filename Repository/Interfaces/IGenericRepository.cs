using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GenericAPI.Contracts.Requests;
using Microsoft.EntityFrameworkCore.Query;

namespace GenericAPI.Repository.Interfaces
{
    public interface IGenericRepository<TEntity, TQuery> where TEntity : class where TQuery : class
    {
        Task<TEntity> GetById(Guid id);
        Task<List<TEntity>> Get(TQuery query);
        Task<TEntity> Create(TEntity entity);
        Task<bool> Create(List<TEntity> entities);
        Task<TEntity> Update(Guid id , TEntity entity);
        Task<bool> Delete(Guid id);   
    }
}
