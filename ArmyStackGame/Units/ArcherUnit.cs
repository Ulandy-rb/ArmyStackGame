using System;
using System.Collections.Generic;
using System.Text;
using ArmyStackGame.Commands;
using ArmyStackGame.SpecialAction;

namespace ArmyStackGame.Units
{
    public class ArcherUnit : Unit, IHealable, ISpecialAction, IUnit
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

		public bool IsFriendly =>false;

		public IUnit Clone()
        {
            return (IUnit)this.MemberwiseClone();
        }
		public void DoSpecialAction(IArmy targetArmy, int position, IEnumerable<int> targetRange)
		{
			if (targetRange == null)
				return;
			if (new Random().Next(100) <= Chance)
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
				IUnit targetUnit = newUnits[new Random().Next(newUnits.Count)];
				var command = new HitCommand(this, targetUnit, Power);
				Engine.GetInstance().CommandManager.RunCommand(command);
			}
		}

		public void Heal(int healPower)
        {
            Health += healPower;
        }

		public override string ToString()
		{
			return $"Archer: {base.ToString()}";
		}
	}
}
