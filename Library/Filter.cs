using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mios.Swiftype {
	public interface IFilter { }

	public class Filter : Dictionary<string, object>, IFilter {
		protected Filter() {
		}
		public static string[] AnyOf(params string[] values) {
			return values;
		}
		public static IFilter AllOf(params string[] values) {
			return new Filter {
				{"type", "and"},
				{"values", values}
			};
		}
	}
}
