using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace Mios.Swiftype {
	public class ToCamelCaseContractResolver : DefaultContractResolver {
		protected override string ResolvePropertyName(string propertyName) {
			return propertyName.Replace("_", "");
		}
	}
}
