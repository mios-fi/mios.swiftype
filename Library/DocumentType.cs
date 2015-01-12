using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mios.Swiftype {
	public class DocumentType : SwiftypeClientBase {
		private string engine;
		private string documentType;
		public DocumentType(string token, string engine, string documentType) : base(token) {
			this.engine = engine;
			this.documentType = documentType;
		}
		public async Task<DocumentTypeResponse> Get() {
			return await Request<DocumentTypeResponse>(HttpMethod.Get, "engines/"+engine+"/document_types/"+documentType+".json", null, null);
		}
		public async Task<DocumentTypeResponse> Delete() {
			return await Request<DocumentTypeResponse>(HttpMethod.Delete, "engines/"+engine+"/document_types/"+documentType+".json", null, null);
		}

		private DocumentCollection documents;
		public DocumentCollection Documents {
			get {
				return documents = documents ?? new DocumentCollection(Token, engine, documentType);
			}
		}

	}
}
