using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mios.Swiftype {
	public class DocumentResponse {
		public string ExternalId { get; set; }
		public string EngineId { get; set; }
		public string DocumentTypeId { get; set; }
		public string Id { get; set; }
		public DateTime UpdatedAt { get; set; }
		public IDictionary<string, object> Fields { get; set; }
		public DocumentResponse() {
			Fields = new Dictionary<string, object>();
		}
	}
}
