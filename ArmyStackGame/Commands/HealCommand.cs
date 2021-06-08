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
		public void Run()
		{
			if (((IUnit)targetUnit).Health + healthPower > ((IUnit)targetUnit).Health)
				realHealtPower = ((IUnit)targetUnit).MaxHealth - ((IUnit)targetUnit).Health;
			targetUnit.Heal(realHealtPower);
		}

		public void Undo()
		{
			((IUnit)targetUnit).Health -= realHealtPower;
		}
	}
}
