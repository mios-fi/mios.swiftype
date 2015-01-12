using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mios.Swiftype {
	public class EngineResponse {
		public string Name { get; set; }
		public string Slug { get; set; }
		public string Key { get; set; }
		public string Id { get; set; }
		public DateTime UpdatedAt { get; set; }
		public int DocumentCount { get; set; }
	}
}
