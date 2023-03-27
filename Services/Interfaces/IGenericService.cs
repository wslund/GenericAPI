using GenericAPI.Contracts.Entities.Iinterfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GenericAPI.Contracts.Requests;
using GenericAPI.Contracts.Query;
using GenericAPI.Contracts.Models;

namespace GenericAPI.Services.Interfaces
{
    public interface IGenericService<TModel, TQuery, TEntity, TRequest> 
        where TModel : class 
        where TQuery : class
        where TEntity : class, IEntity
        where TRequest : class
    {
        Task<TModel> GetById(Guid id);
        Task<List<TModel>> Get(TQuery query);
        Task<TModel> Create(TRequest request);
        Task<TModel> Update(Guid id, TRequest request);
        Task<bool> Delete(Guid id);
    }
}
