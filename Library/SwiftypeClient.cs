using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;
using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;

namespace Mios.Swiftype {
	public class SwiftypeClient : SwiftypeClientBase {
		public SwiftypeClient(string token) : base(token) {
		}
		private EngineCollection engines;
		public EngineCollection Engines {
			get {
				return engines = engines ?? new EngineCollection(Token);
			}
		}
	}
}
