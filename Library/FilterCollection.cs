using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mios.Swiftype {
	public class FilterCollection : Dictionary<string, object> {
		public void Add(string field, string value) {
			base.Add(field, value);
		}
		public void Add(string field, string[] values) {
			base.Add(field, values);
		}
		public void Add(string field, IFilter filter) {
			base.Add(field, filter);
		}
	}
}
