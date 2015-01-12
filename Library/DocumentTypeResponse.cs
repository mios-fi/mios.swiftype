using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mios.Swiftype {
	public class DocumentTypeResponse {
		public string Id { get; set; }
		public string Name { get; set; }
		public string Slug { get; set; }
		public string EngineId { get; set; }
		public DateTime UpdatedAt { get; set; }
		public int DocumentCount { get; set; }
		public IDictionary<string, string> FieldMapping { get; set; }
		public DocumentTypeResponse() {
			FieldMapping = new Dictionary<string, string>();
		}
	}
}
