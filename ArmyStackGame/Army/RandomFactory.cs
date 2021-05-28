using ArmyStackGame.Configs;
using ArmyStackGame.Units;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ArmyStackGame.Army
{
	class RandomFactory : IUnitFactory
	{
		private readonly int minCost = UnitConfig.Units.Min(s => s.Value.Cost); 
		public List<IUnit> CreateArmy(int cost)
		{
			var allUnits = new List<IUnit>();
			while (cost >= minCost)
			{
				var availableUnits = GetAvailableUnitsByCost(cost);
				var index = new Random();
				var randomUnitConfig = availableUnits[index.Next(availableUnits.Count)];

				allUnits.Add(CreateUnit(randomUnitConfig.Key));
				cost -= randomUnitConfig.Value.Cost;
			}
			return allUnits;
		}

		private IUnit CreateUnit(UnitType randomUnitType)
		{
			var creator = CreateCreater(randomUnitType);
			return creator.Create();
		}

		private IUnitCreator CreateCreater(UnitType randomUnitType)
		{
			switch(randomUnitType)
			{
				case UnitType.ArcherUnit:
					return new ArcherUnitCreator();
				case UnitType.HealerUnit:
					return new HealerUnitCreator();
				case UnitType.HeavyUnit:
					return new HeavyUnitUnitCreator();
				case UnitType.LightUnit:
					return new LightUnitCreator();
				case UnitType.MagicUnit:
					return new MagicUnitCreator();
				case UnitType.TumbleweedUnit:
					return new TumbleweedUnitCreator();
				default: return null;
			}
		}

		private List<KeyValuePair<UnitType,UnitParams>> GetAvailableUnitsByCost(int cost)
		{
			return UnitConfig.Units.Where(s => s.Value.Cost <= cost).ToList();
		}
	}
}
