using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mios.Swiftype {
	public class QueryResponse {
		public IDictionary<string, IEnumerable<QueryResult>> Records { get; set; }
		public IDictionary<string, ResponseInfo> Info { get; set; }
		public dynamic Errors { get; set; }

		public class ResponseInfo {
			public string Query { get; set; }
			public int CurrentPage { get; set; }
			public int NumPages { get; set; }
			public int PerPage { get; set; }
			public int TotalResultCount { get; set; }
			public dynamic Facets { get; set; }
		}
	}
	public class QueryResult {
		public string Id { get; set; }
		public string ExternalId { get; set; }
		public DateTimeOffset Date { get; set; }
		public DateTimeOffset UpdatedAt { get; set; }
		public double Score { get; set; }
		public string Type { get; set; }
		public string Index { get; set; }
		public string Version { get; set; }
		public string Sort { get; set; }
		public string Explanation { get; set; }
		public IDictionary<string, string> Highlight { get; set; }
		public IDictionary<string, object> Fields { get; set; }
		public QueryResult() {
			Fields = new Dictionary<string, object>();
			Highlight = new Dictionary<string, string>();
		}
	}
}
