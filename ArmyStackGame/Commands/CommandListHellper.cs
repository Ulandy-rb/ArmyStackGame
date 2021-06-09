using ArmyStackGame.Logger;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArmyStackGame.Commands
{
	internal class CommandListHellper
	{
		private Stack<ICommand> commands = new Stack<ICommand>();
		ILogger logger;
		public CommandListHellper(ILogger logger)
		{
			this.logger = logger;
		}
		public void Add(ICommand command)
		{
			commands.Push(command);
		}
		public void Clear()
		{
			commands.Clear();
		}
		public void Run()
		{
			while(commands.Count>0)
				commands.Pop().Run(logger);
		}
		public void Undo()
		{
			while (commands.Count > 0)
				commands.Pop().Undo(logger);
		}
		public CommandListHellper Copy()
		{
			CommandListHellper other = (CommandListHellper)this.MemberwiseClone();
			var newCommands = new Stack<ICommand>(commands.Distinct().Reverse());
			other.commands = newCommands;
			return other;
		}
	}
}
