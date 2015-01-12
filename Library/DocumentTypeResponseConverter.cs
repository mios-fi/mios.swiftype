using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mios.Swiftype {
	public class DocumentTypeResponseConverter : CustomCreationConverter<DocumentTypeResponse> {
		public override bool CanConvert(Type objectType) {
			return objectType.Equals(typeof(DocumentTypeResponse));
		}
		public override DocumentTypeResponse Create(Type objectType) {
			return new DocumentTypeResponse();
		}
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
			var response = new DocumentTypeResponse();
			while(reader.Read()) {
				if(reader.TokenType!=JsonToken.PropertyName)
					continue;
				var propertyName = reader.Value.ToString();
				if(!reader.Read())
					return null;
				switch(propertyName) {
					case "id":
						response.Id = serializer.Deserialize<string>(reader);
						break;
					case "name":
						response.Name = serializer.Deserialize<string>(reader);
						break;
					case "slug":
						response.Slug = serializer.Deserialize<string>(reader);
						break;
					case "engine_id":
						response.EngineId = serializer.Deserialize<string>(reader);
						break;
					case "updated_at":
						response.UpdatedAt = serializer.Deserialize<DateTime>(reader);
						break;
					case "document_count":
						response.DocumentCount = serializer.Deserialize<int>(reader);
						break;
					default:
						response.FieldMapping[propertyName] = serializer.Deserialize<string>(reader);
						break;
				}
			}
			return response;
		}
	}
}
