using System;
using System.Collections.Generic;
using System.Text;
using ArmyStackGame.Commands;
using ArmyStackGame.SpecialAction;

namespace ArmyStackGame.Units
{
	public class MagicUnit :Unit, ISpecialAction
	{
		public int Chance { get; }

		public int Range { get; }

		public int Power { get; } = 0;

		public bool IsFriendly => true;

		public MagicUnit(int maxhealth, int defense, int attack, int chance, int range) : base(maxhealth, defense, attack)
		{
			Chance = chance;
			Range = range;
			Id = ++Unit.ID;
		}
		
		public void DoSpecialAction(IArmy targetArmy, int position, IEnumerable<int> targetRange)
		{
			if (targetRange == null)
				return;
			if (new Random().Next(100) <= Chance)
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
				IClonable targetUnit = newUnits[new Random().Next(newUnits.Count)];
				var command = new CloneCommand(this, targetUnit, targetArmy);
				Engine.GetInstance().CommandManager.RunCommand(command);
			}
		}
		public override string ToString()
		{
			return $"Mag #{Id}: {base.ToString()}";
		}
	}
}
