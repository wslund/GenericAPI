using GenericAPI.Repository.Interfaces;
using System.Collections.Generic;
using GenericAPI.Contexts;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System;
using GenericAPI.Contracts.Query;
using GenericAPI.Contracts.Entities.Iinterfaces;
using System.Linq;
using GenericAPI.Contracts.Entities;
using Microsoft.EntityFrameworkCore.Query;
using System.Linq.Expressions;
using System.Reflection;


namespace GenericAPI.Repository
{
    public class GenericRepository<TEntity, TQuery> : IGenericRepository<TEntity, TQuery> where TEntity : class, IEntity where TQuery :  PaigeListQuery<TEntity, TQuery>
    {
        internal DataContext _dataContext;
        internal DbSet<TEntity> table;
        private PaigeListQuery<TEntity, TQuery> _paigeList;
        
        

        public GenericRepository(DataContext dataContext)
        {
            _dataContext = dataContext; 
            table = _dataContext.Set<TEntity>();
            
        }

        public virtual async Task<TEntity> GetById(Guid id)
        { 
            var user = table.FirstOrDefault(x => x.Id == id);
            return user;
        }
            


        public virtual async Task<TEntity> Create(TEntity entity)
        {
            var dtn = DateTime.Now;

            entity.Created = dtn;
            entity.Update = dtn;
            

            _dataContext.Add(entity);
            _dataContext.SaveChanges();
              
           return await table.FirstOrDefaultAsync(x => x.Id == entity.Id);
        }

        public virtual async Task<bool> Create(List<TEntity> entities)
        {
            var dtn = DateTime.Now;

            foreach (var entity in entities)
            {
                entity.Created = dtn;
                entity.Update = dtn;

                table.Add(entity);
            }

            await _dataContext.SaveChangesAsync();

            return true;
        }

        
        public virtual async Task<TEntity> Update(Guid id, TEntity entity)
        {
            var existingObj = await table.FirstOrDefaultAsync(x => x.Id == id);

            if (existingObj == null)
                return null;

            entity.Update = DateTime.Now;
            existingObj.Created = existingObj.Created;
            
            
            
            _dataContext.Entry(existingObj).CurrentValues.SetValues(entity);
            _dataContext.SaveChanges();
            return await table.FirstOrDefaultAsync(x => x.Id == id);
        }

        public virtual async Task<bool> Delete(Guid id)
        {
            var deleteObj = await table.FirstOrDefaultAsync(x => x.Id == id);
            
            if (deleteObj == null)
                return false;

            _dataContext.Remove(deleteObj);
            await _dataContext.SaveChangesAsync();
            return true;
        }

        public virtual async Task<List<TEntity>> Get(TQuery query)
        {
            var quaryable = table;
            
            
            var p = query.AddFilter(quaryable, query);

            if (query.PageSize == 0)
                return p.ToList();

            

            return (p.Skip(((query.PageNumber) - 1) * query.PageSize).Take(query.PageSize)).ToList();
        }

        
    }
}
 