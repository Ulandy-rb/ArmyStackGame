﻿using ArmyStackGame.Logger;
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
		public void Run(ILogger logger)
		{
			targetArmy.Units[targetUnitPosition] = ((IImprover)targetUnit).Unit;
			logger.Log($"{currUnit} lost improvment");
		}

		public void Undo(ILogger logger)
		{
			targetArmy.Units[targetUnitPosition] = (IUnit)targetUnit;
		}
	}
}
