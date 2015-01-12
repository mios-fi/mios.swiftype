using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mios.Swiftype {
	public class ReflectionBasedDescriber : IDescriber {
		IDictionary<Type, TypeDefinition> definitions = new Dictionary<Type, TypeDefinition>();

		public Description Parse(object obj) {
			var typeDefinition = GetTypeDefinition(obj.GetType());
			return new Description {
				Id = typeDefinition.IdProperty.GetValue(obj),
				Fields = typeDefinition.Properties.Select(t => new Field {
					Name = t.Name,
					Type = t.Type,
					Value = t.Property.GetValue(obj)
				})
			};
		}

		private static readonly SwiftypeFieldAttribute missingAttribute = new SwiftypeFieldAttribute();
		private TypeDefinition GetTypeDefinition(Type type) {
			TypeDefinition typeDefinition;
			if(definitions.TryGetValue(type, out typeDefinition))
				return typeDefinition;

			var properties = type.GetProperties(BindingFlags.Instance|BindingFlags.DeclaredOnly|BindingFlags.Public);
			var idProperty = properties.FirstOrDefault(t => t.GetCustomAttribute<SwiftypeIdAttribute>()!=null);
			if(idProperty==null)
				idProperty = properties.FirstOrDefault(t => t.Name.Equals("id", StringComparison.OrdinalIgnoreCase));
			if(idProperty==null)
				throw new ArgumentException("Unable to determine identity of type "+type+", either add the SwiftypeIdentity attribute to a property, or add a property named Id.");

			typeDefinition = new TypeDefinition {
				IdProperty = idProperty,
				Properties = properties
					.Where(t => t.GetCustomAttribute<SwiftypeIgnoreAttribute>()==null)
					.Select(t => new { property = t, attribute = t.GetCustomAttribute<SwiftypeFieldAttribute>() ?? missingAttribute })
					.Select(t => new PropertyDefinition {
						Name = t.attribute.Name ?? t.property.Name,
						Type = t.attribute.Type ?? DefaultFieldTypeOf(t.property.PropertyType),
						Property = t.property,
					})
					.ToArray()
			};

			definitions[type] = typeDefinition;
			return typeDefinition;
		}

		private string DefaultFieldTypeOf(Type propertyType) {
			if(propertyType.Equals(typeof(double)) || propertyType.Equals(typeof(float)) || propertyType.Equals(typeof(decimal)))
				return "float";
			if(propertyType.Equals(typeof(int)))
				return "integer";
			if(propertyType.Equals(typeof(DateTime)))
				return "date";
			if(propertyType.IsEnum)
				return "enum";
			return "string";
		}

		struct TypeDefinition {
			public PropertyInfo IdProperty;
			public PropertyDefinition[] Properties;
		}
		struct PropertyDefinition {
			public string Name;
			public string Type;
			public PropertyInfo Property;
		}
	}
}
