using ArmyStackGame.SpecialAction;
using ArmyStackGame.Units;
using ArmyStackGame.Units.ImproveDecorator;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame.Commands
{
	class ImproveCommand : ICommand
	{
		private readonly IUnit currUnit;
		private readonly IImprovable targetUnit;
		private readonly IArmy targetArmy;
		private readonly int targetUnitPosition;
		private readonly IUnit improve;

		public ImproveCommand(IUnit currUnit, IImprovable targetUnit, IArmy targetArmy, int targetUnitPosition, IUnit improve)
		{
			this.currUnit = currUnit;
			this.targetArmy = targetArmy;
			this.targetUnit = targetUnit;
			this.targetUnitPosition = targetUnitPosition;
			this.improve = improve;
		}
		public void Run()
		{
			targetArmy.Units[targetUnitPosition] = improve;
		}

		public void Undo()
		{
			targetArmy.Units[targetUnitPosition] = (IUnit)targetUnit;
		}
	}
}
