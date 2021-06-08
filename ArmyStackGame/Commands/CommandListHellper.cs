using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArmyStackGame.Commands
{
	internal class CommandListHellper
	{
		private Stack<ICommand> commands = new Stack<ICommand>();
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
			commands.Pop().Run();
		}
		public void Undo()
		{
			commands.Pop().Run();
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
