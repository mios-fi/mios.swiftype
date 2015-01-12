using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Mios.Swiftype {
	public interface IDescriber {
		Description Parse(object obj);
	}
	public struct Description {
		public object Id { get; set; }
		public IEnumerable<Field> Fields { get; set; }
	}
	public struct Field {
		public string Name { get; set; }
		public object Value { get; set; }
		public string Type { get; set; }
	}
}
