using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame.Commands
{
	class UndoRedoManager
	{
		private readonly CommandListHellper commandList = new CommandListHellper();
		private readonly Stack<CommandListHellper> undoList = new Stack<CommandListHellper>();
		private readonly Stack<CommandListHellper> redoList = new Stack<CommandListHellper>();
		private bool emptyUndo => undoList.Count == 0;
		private bool emptyRedo => redoList.Count == 0;
		public void RunCommand(ICommand command)
		{
			command.Run();
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
				undoList.Push(tempCommandList);
			}
		}
		public void Undo()
		{
			if (!emptyUndo)
			{
				var tempCommandList = undoList.Pop();
				redoList.Push(tempCommandList);
			}
		}
	}
}
