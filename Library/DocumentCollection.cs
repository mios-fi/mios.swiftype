using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mios.Swiftype {
	public class DocumentCollection : SwiftypeClientBase {
		private readonly string engine;
		private string documentType;
		public DocumentCollection(string token, string engine, string documentType)
			: base(token) {
			this.engine = engine;
			this.documentType = documentType;
		}
		public async Task<DocumentResponse> Get(string id) {
			return await Request<DocumentResponse>(HttpMethod.Get, "engines/"+engine+"/document_types/"+documentType+"/documents/"+id+".json", null, null);
		}
		public async Task<DocumentResponse> Delete(string id) {
			return await Request<DocumentResponse>(HttpMethod.Delete, "engines/"+engine+"/document_types/"+documentType+"/documents/"+id+".json", null, null);
		}
		public async Task<bool[]> Delete(IEnumerable<string> ids) {
			return await Request<bool[]>(HttpMethod.Post, "engines/"+engine+"/document_types/"+documentType+"/documents/bulk_destroy", null, new {
				documents = ids
			});
		}
		public async Task<DocumentResponse> Add(object document) {
			var parsedDocument = FieldParser.Parse(document);
			return await Request<DocumentResponse>(HttpMethod.Post, "engines/"+engine+"/document_types/"+documentType+"/documents/create_or_update", null, new {
				document = new {
					external_id = parsedDocument.Id,
					fields = parsedDocument.Fields
				}
			});
		}
		public async Task<bool[]> Add(IEnumerable<object> documents) {
			return await Request<bool[]>(HttpMethod.Post, "engines/"+engine+"/document_types/"+documentType+"/documents/bulk_create_or_update_verbose", null, new {
				documents = documents.Select(t => {
					var parsedDocument = FieldParser.Parse(t);
					return new {
						external_id = parsedDocument.Id,
						fields = parsedDocument.Fields
					};
				})
			});
		}

		public Task<QueryResponse> Query(string query, int page = 1, FilterCollection filters = null, int? pageSize = null, IEnumerable<string> searchFields = null, IEnumerable<string> fetchFields = null) {
			return Query(new QuerySpecification {
				Q = query, 
				Page = page,
				PerPage = pageSize,
				Filters = { 
					{documentType, filters}
				},
				FetchFields = {
					{documentType, fetchFields}
				},
				SearchFields = { 
					{documentType, searchFields}
				}
			});
		}

		public Task<QueryResponse> Query(QuerySpecification query) {
			return Request<QueryResponse>(
				HttpMethod.Post, 
				"engines/"+engine+"/document_types/"+documentType+"/search.json",
				null,
				query
			);
		}

		public IEnumerable<DocumentResponse> List() {
			int pageIndex = 1;
			while(true) {
				var page = Request<DocumentResponse[]>(HttpMethod.Get, "engines/"+engine+"/document_types/"+documentType+"/documents.json", new Dictionary<string, object> { { "page", pageIndex } }, null)
					.Result;
				if(page.Length==0)
					yield break;
				foreach(var item in page) {
					yield return item;
				}
				pageIndex++;
			}
		}
	}

}