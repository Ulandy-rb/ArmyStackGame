using ArmyStackGame.Logger;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame.Commands
{
	interface ICommand
	{
		void Undo(ILogger logger);
		void Run(ILogger logger);
	}
}
