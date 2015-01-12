using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mios.Swiftype {
	public class DocumentResponseConverter : CustomCreationConverter<DocumentResponse> {
		public override bool CanConvert(Type objectType) {
			return objectType.Equals(typeof(DocumentResponse));
		}
		public override DocumentResponse Create(Type objectType) {
			return new DocumentResponse();
		}
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
			var response = new DocumentResponse();
			while(reader.Read()) {
				if(reader.TokenType==JsonToken.EndObject)
					return response;
				if(reader.TokenType!=JsonToken.PropertyName)
					continue;
				var propertyName = reader.Value.ToString();
				if(!reader.Read())
					return null;
				switch(propertyName) {
					case "id":
					case "_id":
						response.Id = serializer.Deserialize<string>(reader);
						break;
					case "external_id":
						response.ExternalId = serializer.Deserialize<string>(reader);
						break;
					case "engine_id":
						response.EngineId = serializer.Deserialize<string>(reader);
						break;
					case "document_type_id":
						response.DocumentTypeId = serializer.Deserialize<string>(reader);
						break;
					case "updated_at":
						response.UpdatedAt = serializer.Deserialize<DateTime>(reader);
						break;
					default:
						response.Fields[propertyName] = serializer.Deserialize(reader);
						break;
				}
			}
			return response;
		}
	}
}
