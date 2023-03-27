using System.Collections.Generic;

namespace GenericAPI.PropertyMapping
{
    public interface IPropertyMappingService
    {
        bool ValidMappingExistsFor<TSource, TDestination>(string fields);

        Dictionary<string, PropertyMappingValue> GetPropertyMapping
            <TSource, TDestination>();
    }
}
