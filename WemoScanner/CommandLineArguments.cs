using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using DotArguments;
using DotArguments.Attributes;

namespace WemoScanner
{
	public class CommandLineArguments
	{
		// positional arguments

		[PositionalValueArgument(0, "ipRangeStart")]
		[ArgumentDescription(Short = "first IP address to scan, e.g., 192.168.1.20 (IPv4 only)")]
		public string IpRangeStart { get; set; }
		public IPAddress IpRangeStartTyped {
			get
			{
				IPAddress address;
				IPAddress.TryParse(IpRangeStart, out address);
				return address;
			}
		}

		[PositionalValueArgument(1, "ipRangeEnd")]
		[ArgumentDescription(Short = "last IP address to scan, e.g., 192.168.1.254 (IPv4 only)")]
		public string IpRangeEnd { get; set; }
		public IPAddress IpRangeEndTyped
		{
			get
			{
				IPAddress address;
				IPAddress.TryParse(IpRangeEnd, out address);
				return address;
			}
		}

		// value arguments

		// Where to find the baseline db we restore from
		[NamedValueArgument("name", 'n', IsOptional = true)]
		[ArgumentDescription(Short = "the name of the device to find (optional)")]
		public string Name { get; set; }

		[RemainingArguments]
		public string[] RemainingArguments { get; set; }

		public static CommandLineArguments ParseArguments(string[] argArray)
		{
			// create container definition and the parser
			var definition = new ArgumentDefinition(typeof(CommandLineArguments));
			var parser = new GNUArgumentParser();

			CommandLineArguments arguments = null;
			try
			{
				// create object with the populated arguments
				arguments = parser.Parse<CommandLineArguments>(definition, argArray);
			}
			catch (System.Exception ex)
			{
				Console.Error.WriteLine($"Error: {ex.Message}");
				Console.Error.Write(GetUsageString());

				throw;
			}
			return arguments;
		}

		public static string GetUsageString()
		{
			var definition = new ArgumentDefinition(typeof(CommandLineArguments));
			var parser = new GNUArgumentParser();
			return $"Usage: {parser.GenerateUsageString(definition)}";
		}
	}

}
