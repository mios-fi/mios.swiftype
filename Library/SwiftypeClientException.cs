using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mios.Swiftype {
	[Serializable]
	public class SwiftypeClientException : Exception {
		public SwiftypeClientException() { }
		public SwiftypeClientException(SwiftypeClientBase.SwiftypeErrorResponse response) : base(response.Error) { }
		public SwiftypeClientException(string message) : base(message) { }
		public SwiftypeClientException(string message, Exception inner) : base(message, inner) { }
		protected SwiftypeClientException(
		System.Runtime.Serialization.SerializationInfo info,
		System.Runtime.Serialization.StreamingContext context)
			: base(info, context) { }
	}
}
