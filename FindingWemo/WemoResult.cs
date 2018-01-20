using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace FindingWemoNS
{
	public class WemoResult
	{
		public string Name { get; set; }
		public IPAddress IPAddress { get; set; }
		public int Port { get; set; }

		public WemoResult(string name, IPAddress ipAddress, int port)
		{
			Name = name;
			IPAddress = ipAddress;
			Port = port;
		}
	}
}
