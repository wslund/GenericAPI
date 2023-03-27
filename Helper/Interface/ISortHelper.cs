using GenericAPI.Contracts.Entities;
using GenericAPI.PropertyMapping;
using System.Collections.Generic;
using System.Linq;

namespace GenericAPI.Helper.Interface
{
    public interface ISortHelper<TEntity> : IPropertyMappingService
    {

        IQueryable<TEntity?> ApplySort(IQueryable<TEntity> entities, string QueryString, Dictionary<string, PropertyMappingValue> mappingDictionary);
        IQueryable<UserEntity> ApplySort(IQueryable<UserEntity> quaryable, string orderBy, Dictionary<string, PropertyMappingValue> dictionary, object mappingDictionary);
    }
}
