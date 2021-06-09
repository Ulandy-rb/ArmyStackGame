using ArmyStackGame.Logger;
using ArmyStackGame.SpecialAction;
using ArmyStackGame.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame.Commands
{
	class CloneCommand : ICommand
	{
		private readonly IUnit currUnit;
		private readonly IClonable targetUnit;
		private readonly IArmy targetArmy;

		public CloneCommand(IUnit currUnit, IClonable targetUnit, IArmy targetArmy)
		{
			this.currUnit = currUnit;
			this.targetArmy = targetArmy;
			this.targetUnit = targetUnit;
		}
		public void Run(ILogger logger)
		{
			var newUnit = targetUnit.Clone();
			targetArmy.Units.Add((IUnit)newUnit);
			logger.Log($"{currUnit} clone {targetUnit}");
		}

		public void Undo(ILogger logger)
		{
			targetArmy.Units.RemoveAt(targetArmy.Units.Count - 1);
		}
	}
}
