using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mios.Swiftype {
	public class QueryResponse {
		public IDictionary<string, IEnumerable<dynamic>> Records { get; set; }
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
}
