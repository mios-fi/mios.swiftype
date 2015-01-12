using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mios.Swiftype {
	public class DocumentTypeCollection : SwiftypeClientBase {
		private readonly string engine;
		public DocumentTypeCollection(string token, string engine)
			: base(token) {
			this.engine = engine;
		}
		public async Task<DocumentTypeResponse> Create(string name) {
			return await Request<DocumentTypeResponse>(HttpMethod.Post, "engines/"+engine+"/document_types.json", null, new {
				document_type = new { name }
			});
		}
		public async Task<DocumentTypeResponse[]> List() {
			return await Request<DocumentTypeResponse[]>(HttpMethod.Get, "engines/"+engine+"/document_types.json", null, null);
		}
		public DocumentType this[string name] {
			get {
				return new DocumentType(Token, engine, name);
			}
		}
	}
}
