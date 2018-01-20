using System;
using System.Diagnostics;
using System.Linq;
using FindingWemoNS;

namespace FindingWemoConsole
{
	class Program
	{
		static void Main(string[] arguments)
		{
			CommandLineArguments args = null;
			try
			{
				args = GetArguments(arguments);
			}
			catch
			{
				ExitWithCode(1);
			}
			var result = FindingWemo.Search(args.IpRangeStartTyped, args.IpRangeEndTyped, args.Name).SingleOrDefault();
			if (result == null)
				Console.WriteLine($"Not found");
			else
				Console.WriteLine($"Found at {result.IPAddress}:{result.Port} - Name:[{result.Name}]");

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
