using GenericAPI.Contracts.Entities;
using GenericAPI.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GenericAPI.PropertyMapping
{
    public class PropertyMappingService : IPropertyMappingService
	{
		private readonly IList<IPropertyMapping> _propertyMappings = new List<IPropertyMapping>();



		public PropertyMappingService()
		{

			_propertyMappings.Add(new PropertyMapping<UserModel, UserEntity>(UserMapping()));
			_propertyMappings.Add(new PropertyMapping<RoleModel, RoleEntity>(RoleMapping()));
			_propertyMappings.Add(new PropertyMapping<CompanyModel, CompanyEntity>(CompanyMapping()));


		}

		public bool ValidMappingExistsFor<TSource, TDestination>(string fields)
		{
			var propertyMapping = GetPropertyMapping<TSource, TDestination>();

			if (string.IsNullOrWhiteSpace(fields))
			{
				return true;
			}

			var fieldsAfterSplit = fields.Split(',');

			return (
				from field
					in fieldsAfterSplit
				select field.Trim()
				into trimmedField
				let indexOfFirstSpace = trimmedField.IndexOf(" ", StringComparison.Ordinal)
				select indexOfFirstSpace == -1
					? trimmedField
					: trimmedField.Remove(indexOfFirstSpace))
				.All(propertyName => propertyMapping.ContainsKey(propertyName));
		}

		public Dictionary<string, PropertyMappingValue> GetPropertyMapping
		<TSource, TDestination>()
		{
			var matchingMapping = _propertyMappings
				.OfType<PropertyMapping<TSource, TDestination>>();

			var propertyMappings = matchingMapping.ToList();
			if (propertyMappings.Count() == 1)
			{
				return propertyMappings.First().MappingDictionary;
			}

			throw new Exception($"Cannot find property mapping instance for {typeof(TSource)}, {typeof(TDestination)}");
		}

		private static Dictionary<string, PropertyMappingValue> UserMapping()
		{
			return new(StringComparer.OrdinalIgnoreCase)
			{
				{ "Id", new PropertyMappingValue(new List<string> { "Id" }) },
				{ "FirstName", new PropertyMappingValue(new List<string> { "FirstName" }) },
				{ "LastName", new PropertyMappingValue(new List<string> { "LastName" }) },
				{ "Created", new PropertyMappingValue(new List<string> { "Created" }) },
				{ "Updated", new PropertyMappingValue(new List<string> { "Updated" }) },
				{ "Age", new PropertyMappingValue(new List<string> { "DateOfBirth" }) },
			};
		}

		private static Dictionary<string, PropertyMappingValue> RoleMapping()
		{
			return new(StringComparer.OrdinalIgnoreCase)
			{
				{ "Id", new PropertyMappingValue(new List<string> { "Id" }) },
				{ "Created", new PropertyMappingValue(new List<string> { "Created" }) },
				{ "Updated", new PropertyMappingValue(new List<string> { "Updated" }) },
				{ "Role", new PropertyMappingValue(new List<string> { "Role" }) },
			};
		}

		private static Dictionary<string, PropertyMappingValue> CompanyMapping()
		{
			return new(StringComparer.OrdinalIgnoreCase)
			{
				{ "Id", new PropertyMappingValue(new List<string> { "Id" }) },
				{ "Name", new PropertyMappingValue(new List<string> { "Name" }) },
				{ "Discription", new PropertyMappingValue(new List<string> { "Discription" }) },
				{ "Created", new PropertyMappingValue(new List<string> { "Created" }) },
				{ "Updated", new PropertyMappingValue(new List<string> { "Updated" }) },
				{ "Role", new PropertyMappingValue(new List<string> { "Role" }) },
			};
		}

	}
}
