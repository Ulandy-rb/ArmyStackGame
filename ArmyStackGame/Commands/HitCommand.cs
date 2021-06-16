using ArmyStackGame.Logger;
using ArmyStackGame.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame.Commands
{
	class HitCommand : ICommand
	{
		private readonly IUnit currUnit;
		private readonly IUnit targetUnit;
		private readonly int maxDamage;
		private int realDamage;
		public HitCommand(IUnit currUnit, IUnit targetUnit, int damage)
		{
			this.currUnit = currUnit;
			this.targetUnit = targetUnit;
			maxDamage = realDamage = damage;
		}
		public void Run(ILogger logger)
		{
			realDamage = maxDamage*(100 - targetUnit.Defense)/100;
			if (realDamage > targetUnit.Health)
				realDamage = targetUnit.Health;
			targetUnit.TakeDamage(realDamage);
			logger.Log($"\u203C {currUnit} hit {targetUnit} for {realDamage} points\n");
		}

		public void Undo(ILogger logger)
		{
			targetUnit.Health += realDamage;
		}
	}
}
