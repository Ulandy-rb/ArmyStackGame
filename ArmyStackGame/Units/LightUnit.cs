using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using ArmyStackGame.Commands;
using ArmyStackGame.SpecialAction;
using ArmyStackGame.Units.ImproveDecorator;

namespace ArmyStackGame.Units
{
	class LightUnit : Unit, IUnit, IHealable, ISpecialAction
	{
		public LightUnit(int maxhealth, int defense, int attack, int chance, int range) : base (maxhealth, defense, attack)
		{
            Chance = chance;
			Range = range;
		}

		public int Chance { get; }

		public int Range { get; }

		public int Power { get; } = 0;

		public IUnit Clone()
        {
            return (IUnit)this.MemberwiseClone();
        }
		public void DoSpecialAction(IArmy targetArmy, int position, IEnumerable<int> targetRange)
		{
			if (new Random().Next() <= Chance)
			{
				var newUnits = new List<Tuple<int, IImprovable>>();
				foreach (var index in targetRange)
				{
					if (index == position)
						continue;
					var currUnit = targetArmy.Units[index];
					if (currUnit is IImprovable improvableUnit && currUnit.IsAlive)
					{
						newUnits.Add(new Tuple<int, IImprovable>(index, improvableUnit));
					}
				}
				if (newUnits.Count == 0)
					return;
				var target = newUnits[new Random().Next(targetArmy.Units.Count)];
				var targetUnit = target.Item2;
				var targetIndexPosition = target.Item1;

				var baseImproveType = typeof(ImproveDecorator<>);
				var types = baseImproveType.Assembly.GetTypes()
					.Where(type => type.BaseType != null && type.BaseType.IsGenericType && type.BaseType.GetGenericTypeDefinition() == baseImproveType)
					.ToList();

				for (int i = 0; i < types.Count; i++)
				{
					var type = types[i];
					if(targetUnit.CanImprove(type))
					{
						var improve = type.MakeGenericType(targetUnit.GetType());
						var targetImprove = (IUnit)Activator.CreateInstance(improve, targetUnit);

						var command = new ImproveCommand(this, targetUnit, targetArmy, targetIndexPosition, targetImprove);
						new UndoRedoManager().RunCommand(command);
						break;
					}
					types.RemoveAt(i);
				}
			}
		}

		public void Heal(int healPower)
        {
            Health += healPower;
        }
    }
}
