using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mios.Swiftype {
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public sealed class SwiftypeFieldAttribute : Attribute {
		public string Type { get; set; }
		public string Name { get; set; }
		public bool Ignore { get; set; }
	}
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public sealed class SwiftypeIdAttribute : Attribute {
	}
	[AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
	public sealed class SwiftypeIgnoreAttribute : Attribute {
	}
}
