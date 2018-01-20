using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace FindingWemoNS
{
	public class FindingWemo
	{
		public static IEnumerable<WemoResult> Search(IPAddress ipRangeStart, IPAddress ipRangeEnd, string searchName = null)
		{
			var possiblePorts = new List<int> { 49154, 49153, 49152 };

			var ipBytes = ipRangeStart.GetAddressBytes();
			int lastOctetStart = ipRangeStart.GetAddressBytes()[3];
			int lastOctetEnd = ipRangeEnd.GetAddressBytes()[3];
			bool isNameSearch = !string.IsNullOrWhiteSpace(searchName);

			string subnet = $"{ipBytes[0]}.{ipBytes[1]}.{ipBytes[2]}";

			using (var httpClient = new HttpClient())
			{
				httpClient.Timeout = TimeSpan.FromSeconds(5);
				var results = new List<WemoResult>();
				Parallel.For(lastOctetStart, lastOctetEnd + 1, (index, loopState) =>
				{
					foreach (var port in possiblePorts)
					{
						var url = $"http://{subnet}.{index}:{port}/setup.xml";
						var responseResult = httpClient.GetAsync(url);
						string resp = null;
						try
						{
							resp = responseResult.Result.Content.ReadAsStringAsync().Result;
						}
						catch { }

						if (!string.IsNullOrWhiteSpace(resp))
						{
							var info = WemoSetup.GetFromXml(resp);
							var friendlyName = info.device.friendlyName;
							results.Add(new WemoResult(friendlyName, IPAddress.Parse($"{subnet}.{index}"), port));

							if (isNameSearch && friendlyName.ToLowerInvariant().StartsWith(searchName.ToLowerInvariant()))
								loopState.Break();

							break;
						}
					}
				});

				return results;
			}
		}
	}
}
