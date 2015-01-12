using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Newtonsoft.Json.Serialization;

namespace Mios.Swiftype {
	public class ToSnakeCaseContractResolver : DefaultContractResolver {
		Regex pattern = new Regex(@"(?<=\p{Ll})\p{Lu}(?=\p{Ll})");
		protected override string ResolvePropertyName(string propertyName) {
			return pattern.Replace(propertyName, @"_$0").ToLowerInvariant();
		}
	}
}
