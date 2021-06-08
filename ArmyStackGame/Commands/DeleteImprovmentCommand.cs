using ArmyStackGame.SpecialAction;
using ArmyStackGame.Units;
using ArmyStackGame.Units.ImproveDecorator;
using ArmyStackGame.Units.ImproveDecorator.Improvements;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame.Commands
{
	class DeleteImprovmentCommand : ICommand
	{
		private readonly IUnit currUnit;
		private readonly IImprovable targetUnit;
		private readonly IArmy targetArmy;
		private readonly int targetUnitPosition;

		public DeleteImprovmentCommand(IUnit currUnit, IImprovable targetUnit, IArmy targetArmy, int targetUnitPosition)
		{
			this.currUnit = currUnit;
			this.targetArmy = targetArmy;
			this.targetUnit = targetUnit;
			this.targetUnitPosition = targetUnitPosition;
		}
		public void Run()
		{
			targetArmy.Units[targetUnitPosition] = ((IImprover)targetUnit).Unit;
		}

		public void Undo()
		{
			targetArmy.Units[targetUnitPosition] = (IUnit)targetUnit;
		}
	}
}
