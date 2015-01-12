using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mios.Swiftype {
	public class Engine : SwiftypeClientBase {
		private string engine;
		public Engine(string token, string name)
			: base(token) {
			this.engine = name;
		}
		public async Task<EngineResponse> Get() {
			return await Request<EngineResponse>(HttpMethod.Get, "engines/"+engine+".json", null, null);
		}
		public async Task<EngineResponse> Delete() {
			return await Request<EngineResponse>(HttpMethod.Delete, "engines/"+engine+".json", null, null);
		}

		public Task<QueryResponse> Query(string query, int page = 1, IDictionary<string,FilterCollection> filters = null, int? pageSize = null, IDictionary<string,IEnumerable<string>> searchFields = null, IDictionary<string,IEnumerable<string>> fetchFields = null) {
			return Query(new QuerySpecification {
				Q = query,
				Page = page,
				PerPage = pageSize,
				Filters = filters,
				FetchFields = fetchFields,
				SearchFields = searchFields
			});
		}

		public Task<QueryResponse> Query(QuerySpecification query) {
			return Request<QueryResponse>(
				HttpMethod.Post,
				"engines/"+engine+"/search.json",
				null,
				query
			);
		}

		private DocumentTypeCollection documentTypes;
		public DocumentTypeCollection DocumentTypes {
			get {
				return documentTypes = documentTypes ?? new DocumentTypeCollection(Token, engine);
			}
		}
	}
}
