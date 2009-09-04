using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Community.Example
{
	class Programm
	{
		public static void Main()
		{
			var config = DataConnectionConfiguration.GetDefault();

			Console.WriteLine("Server: {0}", config.Server);
			Console.WriteLine("Database: {0}", config.Database);
			Console.WriteLine("Username: {0}", config.Username);
			Console.WriteLine("Timeout: {0}", config.Timeout);
		}
	}
}
