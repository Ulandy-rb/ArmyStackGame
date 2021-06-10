using ArmyStackGame.Logger;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame.Commands
{
	public class UndoRedoManager
	{
		private readonly CommandListHellper commandList;
		private readonly Stack<CommandListHellper> undoList = new Stack<CommandListHellper>();
		private readonly Stack<CommandListHellper> redoList = new Stack<CommandListHellper>();
		public bool emptyUndo => undoList.Count == 0;
		public bool emptyRedo => redoList.Count == 0;

		ILogger logger;

		public UndoRedoManager(ILogger logger)
		{
			this.logger = logger;
			commandList = new CommandListHellper(logger);
		}
		public void RunCommand(ICommand command)
		{
			command.Run(logger);
			commandList.Add(command);	
		}
		public void EndTurn()
		{
			var tempCommandList = commandList.Copy();
			redoList.Clear();
			undoList.Push(tempCommandList);
			commandList.Clear();
		}

		public void Redo()
		{
			if (!emptyRedo)
			{
				var tempCommandList = redoList.Pop();
				tempCommandList.Run();
				undoList.Push(tempCommandList);				
			}
		}
		public void Undo()
		{
			if (!emptyUndo)
			{
				var tempCommandList = undoList.Pop();
				tempCommandList.Undo();
				redoList.Push(tempCommandList);				
			}
		}
	}
}
