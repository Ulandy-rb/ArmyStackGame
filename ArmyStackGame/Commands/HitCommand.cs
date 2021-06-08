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
		public void Run()
		{
			if (targetUnit.Defense != 0)
				realDamage = maxDamage - maxDamage / targetUnit.Defense;
			if (realDamage > targetUnit.Health)
				realDamage = targetUnit.Health;
			targetUnit.TakeDamage(realDamage);
		}

		public void Undo()
		{
			targetUnit.Health += realDamage;
		}
	}
}
