using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame.Logger
{
	class ConsoleLogger : ILogger
	{
		public void Log(string message)
		{
			Console.WriteLine(message);
		}
	}
}
