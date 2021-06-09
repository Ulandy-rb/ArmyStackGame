using ArmyStackGame.Logger;
using ArmyStackGame.SpecialAction;
using ArmyStackGame.Units;
using System;
using System.Collections.Generic;
using System.Text;

namespace ArmyStackGame.Commands
{
	class HealCommand : ICommand
	{
		private readonly IUnit currUnit;
		private readonly IHealable targetUnit;
		private readonly int healthPower;
		private int realHealtPower;

		public HealCommand(IUnit currUnit, IHealable targetUnit, int healthPower)
		{
			this.currUnit = currUnit;
			this.targetUnit = targetUnit;
			this.healthPower = realHealtPower = healthPower;
		}
		public void Run(ILogger logger)
		{
			if (((IUnit)targetUnit).Health + healthPower > ((IUnit)targetUnit).Health)
				realHealtPower = ((IUnit)targetUnit).MaxHealth - ((IUnit)targetUnit).Health;
			targetUnit.Heal(realHealtPower);
			logger.Log($"{currUnit} heal {targetUnit} for {healthPower} points");
		}

		public void Undo(ILogger logger)
		{
			((IUnit)targetUnit).Health -= realHealtPower;
		}
	}
}
