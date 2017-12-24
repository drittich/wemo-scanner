using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Threading.Tasks;

namespace WemoScanner
{
	class Program
	{
		static void Main(string[] arguments)
		{
			CommandLineArguments args = GetArguments(arguments);

			int lastOctetStart = args.IpRangeStartTyped.GetAddressBytes()[3];
			int lastOctetEnd = args.IpRangeEndTyped.GetAddressBytes()[3];
			var possiblePorts = new List<int> { 49154, 49153, 49152 };
			var ipBytes = args.IpRangeStartTyped.GetAddressBytes();
			string subnet = $"{ipBytes[0]}.{ipBytes[1]}.{ipBytes[2]}";

			using (var httpClient = new HttpClient())
			{
				httpClient.Timeout = TimeSpan.FromSeconds(5);
				Parallel.For(lastOctetStart, lastOctetEnd + 1, (index) =>
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
							var setup = WemoSetup.GetFromXml(resp);
							Console.WriteLine($"Found at {subnet}.{index}:{port} - Name:[{setup.device.friendlyName}] MAC:{setup.device.macAddress}");
							break;
						}
					}
				});
			}

			ExitWithCode(0, "Done");
		}

		static CommandLineArguments GetArguments(string[] arguments)
		{
			CommandLineArguments args = null;
			try
			{
				args = CommandLineArguments.ParseArguments(arguments);
			}
			catch (DotArguments.Exceptions.MandatoryArgumentMissingException)
			{
				ExitWithCode(1);
			}

			return args;
		}

		static void ValidateArgs(CommandLineArguments args)
		{

			if (args.IpRangeStartTyped == null || args.IpRangeEndTyped == null)
				ExitWithCode(1, "Invalid start or end IPv4 address");
		}

		static void ExitWithCode(int exitCode, string message = null)
		{
			if (message != null)
				Console.WriteLine(message);
			if (Debugger.IsAttached)
				Console.ReadKey();
			Environment.Exit(exitCode);
		}
	}
}
