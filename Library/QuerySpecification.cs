using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mios.Swiftype {
	public class QuerySpecification {
		public string Q { get; set; }
		public int Page { get; set; }
		public int? PerPage { get; set; }
		public string[] DocumentTypes { get; set; }
		public IDictionary<string, FilterCollection> Filters { get; set; }
		public IDictionary<string, IEnumerable<string>> SearchFields { get; set; }
		public IDictionary<string, IEnumerable<string>> FetchFields { get; set; }
		public QuerySpecification() {
			Page = 1;
			Filters = new Dictionary<string, FilterCollection>();
			SearchFields = new Dictionary<string, IEnumerable<string>>();
			FetchFields = new Dictionary<string, IEnumerable<string>>();
		}
	}
}
