using System;
using System.Collections.Generic;
using System.Text;
using ArmyStackGame.Commands;
using ArmyStackGame.SpecialAction;

namespace ArmyStackGame.Units
{
	class MagicUnit :Unit, ISpecialAction
	{
		public int Chance { get; }

		public int Range { get; }

		public int Power { get; } = 0;
		public MagicUnit(int maxhealth, int defense, int attack, int chance, int range) : base(maxhealth, defense, attack)
		{
			Chance = chance;
			Range = range;
		}
		
		public void DoSpecialAction(IArmy targetArmy, int position, IEnumerable<int> targetRange)
		{
			if (new Random().Next() <= Chance)
			{
				var newUnits = new List<IClonable>();
				foreach (var index in targetRange)
				{
					if (index == position)
						continue;
					var currUnit = targetArmy.Units[index];
					if (currUnit is IClonable clonableUnit && currUnit.IsAlive)
					{
						newUnits.Add(clonableUnit);
					}
				}
				if (newUnits.Count == 0)
					return;
				IClonable targetUnit = newUnits[new Random().Next(targetArmy.Units.Count)];
				var command = new CloneCommand(this, targetUnit, targetArmy);
				new UndoRedoManager().RunCommand(command);
			}
		}
	}
}
