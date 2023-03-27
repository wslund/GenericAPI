using AutoMapper;
using GenericAPI.Contexts;
using GenericAPI.Contracts.Entities.Iinterfaces;
using GenericAPI.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using GenericAPI.Contracts.Models;
using GenericAPI.Contracts.Query;
using GenericAPI.Contracts.Requests;
using GenericAPI.Repository.Interfaces;

namespace GenericAPI.Services
{
    public class GenericService <TModel, TQuery, TEntity, TRequest> : IGenericService<TModel, TQuery, TEntity, TRequest> 
        where TModel : class
        where TQuery : class
        where TEntity : class, IEntity
        where TRequest: class
        
    {
        private readonly IGenericRepository<TEntity,TQuery> _genericRepository;
        private readonly IMapper _mapper;
        private IMapper mapper;

        public GenericService(IMapper mapper, IGenericRepository<TEntity, TQuery> genericRepository)

        {
            _genericRepository = genericRepository;
            _mapper = mapper;
        }

        

        public virtual async Task<TModel> GetById(Guid id)
        {
            var returnObj = await _genericRepository.GetById(id);
            return _mapper.Map<TEntity, TModel>(returnObj);
        }

        public virtual async Task<List<TModel>> Get(TQuery query)
        {
            var returnObj = await _genericRepository.Get(query);
            return _mapper.Map<List<TEntity>, List<TModel>>(returnObj);
        }

        
        public virtual async Task<TModel> Update(Guid id, TRequest request)
        {
            var obj = _mapper.Map<TRequest, TEntity>(request);
            obj.Id = id;
            var returnObj = await _genericRepository.Update(id, obj);

            if (returnObj == null)
                return null;

            return _mapper.Map<TEntity, TModel>(returnObj);
        }

        public virtual async Task<bool> Delete(Guid id)
        {
            return await _genericRepository.Delete(id);
        }

        public virtual async Task<TModel> Create(TRequest request)
        {
            var obj = _mapper.Map<TRequest,TEntity>(request);
            var returnObj = await _genericRepository.Create(obj);

            return _mapper.Map<TEntity, TModel>(returnObj);
        }
    }
}
