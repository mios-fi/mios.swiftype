using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;

namespace Mios.Swiftype {
	public abstract class SwiftypeClientBase {
		private static readonly Uri apiBaseUri = new Uri("https://api.swiftype.com/api/v1/");
		private static readonly JsonSerializerSettings serializingSettings = new JsonSerializerSettings {
			ContractResolver = new ToSnakeCaseContractResolver()
		};
		private static readonly JsonSerializerSettings deserializingSettings = new JsonSerializerSettings {
			ContractResolver = new ToSnakeCaseContractResolver(),
			Converters = {
				new DocumentResponseConverter()
			}
		};

		public IDescriber FieldParser { get; set; }
		public string Token { get; set; }
		protected SwiftypeClientBase(string token) {
			this.Token = token;
			FieldParser = new ReflectionBasedDescriber();
		}

		private static readonly IDictionary<string, object> emptyParameters = new Dictionary<string, object>();
		protected virtual async Task<TResponse> Request<TResponse>(HttpMethod method, string path, IDictionary<string, object> parameters, object payload) {
			var queryString = "?" + String.Join("&", new Dictionary<string,object>(parameters ?? emptyParameters) { {"auth_token", Token} }
					.Select(t => Uri.EscapeUriString(t.Key)+"="+Uri.EscapeUriString(t.Value.ToString()))
			);
			var encodedPayload = JsonConvert.SerializeObject(payload, serializingSettings);
			var request = new HttpRequestMessage(method, new Uri(apiBaseUri, path + queryString));
			if(payload!=null) {
				request.Content = new StringContent(encodedPayload, Encoding.UTF8, "application/json");
			}
			var response = await new HttpClient().SendAsync(request);
			var responseContent = await response.Content.ReadAsStringAsync();
			if(response.IsSuccessStatusCode) 
				return JsonConvert.DeserializeObject<TResponse>(responseContent, deserializingSettings);

			if(response.Content.Headers.ContentType.MediaType == "application/json") 
				throw new SwiftypeClientException(JsonConvert.DeserializeObject<SwiftypeErrorResponse>(responseContent, deserializingSettings));

			throw new SwiftypeClientException(responseContent);
		}

		public struct SwiftypeErrorResponse {
			public string Error { get; set; }
		}
	}
}
