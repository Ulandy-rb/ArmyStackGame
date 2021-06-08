using System;
using System.Collections.Generic;
using System.Text;
using ArmyStackGame.Commands;
using ArmyStackGame.SpecialAction;

namespace ArmyStackGame.Units
{
    class ArcherUnit : Unit, IHealable, ISpecialAction, IUnit
    {
        public ArcherUnit(int maxhealth, int defense, int attack, int chance, int range, int power) : base(maxhealth, defense, attack)
        {
            Chance = chance;
            Range = range;
            Power = power;
        }

        public int Chance { get; }

		public int Range { get; }

		public int Power { get; }

		public IUnit Clone()
        {
            return (IUnit)this.MemberwiseClone();
        }
		public void DoSpecialAction(IArmy targetArmy, int position, IEnumerable<int> targetRange)
		{
			if (new Random().Next() <= Chance)
			{
				var newUnits = new List<IUnit>();
				foreach (var index in targetRange)
				{
					if (index == position)
						continue;
					var currUnit = targetArmy.Units[index];
					if (currUnit.IsAlive)
					{
						newUnits.Add(currUnit);
					}
				}
				if (newUnits.Count == 0)
					return;
				IUnit targetUnit = newUnits[new Random().Next(targetArmy.Units.Count)];
				var command = new HitCommand(this, targetUnit, Power);
				new UndoRedoManager().RunCommand(command);
			}
		}

		public void Heal(int healPower)
        {
            Health += healPower;
        }
    }
}
