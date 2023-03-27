using GenericAPI.Helper.Interface;
using System.Reflection;
using System.Text;
using System.Linq.Dynamic.Core;
using System.Linq;
using System.Text.RegularExpressions;
using System;
using GenericAPI.PropertyMapping;
using System.Collections.Generic;

namespace GenericAPI.Helper
{
    public class SortHelper<TEntity>
    {
        private readonly IPropertyMappingService _propertyMappingService;

        public IQueryable<TEntity> ApplySort(IQueryable<TEntity> entities, string QueryString, Dictionary<string, PropertyMappingValue> mappingDictionary)
        {
			if (entities == null)
			{
				throw new ArgumentNullException(nameof(entities));
			}

			if (mappingDictionary == null)
			{
				throw new ArgumentNullException(nameof(mappingDictionary));
			}

			if (string.IsNullOrWhiteSpace(QueryString))
			{
				return entities;
			}

			var orderByAfterSplit = QueryString.Split(',');
			var orderByStr = "";

			foreach (var orderByClause in orderByAfterSplit.Reverse())
			{
				var trimmedOrderByClause = orderByClause.Trim();

				var orderDescending = trimmedOrderByClause.EndsWith(" desc");

				var indexOfFirstSpace = trimmedOrderByClause.IndexOf(" ", StringComparison.Ordinal);
				var propertyName = indexOfFirstSpace == -1
					? trimmedOrderByClause
					: trimmedOrderByClause.Remove(indexOfFirstSpace);

				if (!mappingDictionary.ContainsKey(propertyName))
				{
					throw new ArgumentException($"Key mapping for {propertyName} is missing");
				}

				var propertyMappingValue = mappingDictionary[propertyName];

				if (propertyMappingValue == null)
				{
					throw new ArgumentNullException(nameof(propertyMappingValue));
				}

				foreach (var destinationProperty in
					propertyMappingValue.DestinationProperties.Reverse())
				{
					if (propertyMappingValue.Revert)
					{
						orderDescending = !orderDescending;
					}

					orderByStr = orderByStr
								 + (string.IsNullOrWhiteSpace(orderByStr) ? string.Empty : ", ")
								 + destinationProperty
								 + (orderDescending ? " descending" : " ascending");
				}
			}

			return entities.OrderBy(orderByStr);
		}

       
    }
}
