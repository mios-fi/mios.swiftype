using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Mios.Swiftype {
	public class EngineCollection : SwiftypeClientBase {
		public EngineCollection(string token)
			: base(token) {
		}
		public async Task<EngineResponse> Create(string name) {
			return await Request<EngineResponse>(HttpMethod.Post, "engines.json", null, new {
				engine = new { name }
			});
		}
		public async Task<EngineResponse[]> List() {
			return await Request<EngineResponse[]>(HttpMethod.Get, "engines.json", null, null);
		}
		public Engine this[string name] {
			get {
				return new Engine(Token, name);
			}
		}
	}
}
