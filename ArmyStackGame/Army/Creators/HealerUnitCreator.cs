using ArmyStackGame.Configs;
using ArmyStackGame.Units;

namespace ArmyStackGame.Army
{
	internal class HealerUnitCreator : IUnitCreator
	{
		public IUnit Create()
		{
			var healer = UnitConfig.Units[UnitType.HealerUnit];
			return new HealerUnit(healer.Health, healer.Defense, healer.Attack, healer.Chance, healer.Range, healer.Power);
		}
	}
}