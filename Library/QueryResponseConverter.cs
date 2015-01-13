using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Mios.Swiftype {
	public class QueryResultConverter : CustomCreationConverter<QueryResult> {
		public override bool CanConvert(Type objectType) {
			return objectType.Equals(typeof(QueryResult));
		}
		public override QueryResult Create(Type objectType) {
			return new QueryResult();
		}
		public override object ReadJson(JsonReader reader, Type objectType, object existingValue, JsonSerializer serializer) {
			var response = new QueryResult();
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
					case "_index":
						response.Index = serializer.Deserialize<string>(reader);
						break;
					case "_type":
						response.Type = serializer.Deserialize<string>(reader);
						break;
					case "_version":
						response.Version = serializer.Deserialize<string>(reader);
						break;
					case "_explanation":
						response.Explanation = serializer.Deserialize<string>(reader);
						break;
					case "_score":
						response.Score = serializer.Deserialize<double>(reader);
						break;
					case "date":
						response.UpdatedAt = serializer.Deserialize<DateTime>(reader);
						break;
					case "sort":
						response.Sort = serializer.Deserialize<string>(reader);
						break;
					case "updated_at":
						response.UpdatedAt = serializer.Deserialize<DateTime>(reader);
						break;
					case "highlight":
						response.Highlight = serializer.Deserialize<IDictionary<string,string>>(reader);
						break;
					default:
						if(reader.TokenType==JsonToken.String)
							response.Fields[propertyName] = serializer.Deserialize<string>(reader);
						else if(reader.TokenType==JsonToken.StartArray) 
							response.Fields[propertyName] = serializer.Deserialize<string[]>(reader);
						break;
				}
			}
			return response;
		}
	}
}
